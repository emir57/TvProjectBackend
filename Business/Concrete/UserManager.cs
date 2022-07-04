using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.Validators.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Security.Hashing;
using Core.Utilities.Email;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IUserCodeService _userCodeService;
        private readonly IEmailService _emailService;
        public UserManager(IUserDal userDal, IUserCodeService userCodeService, IEmailService emailService)
        {
            _userDal = userDal;
            _userCodeService = userCodeService;
            _emailService = emailService;
        }
        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        [PerformanceAspect(3)]
        public async Task<IResult> AddAsync(User user)
        {
            await _userDal.AddAsync(user);
            return new SuccessResult(Messages.SuccessAdd);
        }

        public async Task<IResult> AddUserRoleAsync(User user)
        {
            await _userDal.AddUserRoleAsync(user);
            return new SuccessResult();
        }

        public async Task<IDataResult<User>> GetByIdAsync(int userId)
        {
            User user = await _userDal.GetAsync(x => x.Id == userId);
            if (user == null)
                return new ErrorDataResult<User>(Messages.UserNotFound);
            return new SuccessDataResult<User>(user, Messages.SuccessGet);
        }
        public async Task<IDataResult<User>> GetByKeyAsync(string key)
        {
            User user = await _userDal.GetAsync(x => x.Key == key);
            return new SuccessDataResult<User>(user, Messages.SuccessGet);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public async Task<IDataResult<List<UserForAddressDto>>> GetListAddressAsync(User user)
        {
            List<UserForAddressDto> userForAddressDtos = await _userDal.GetAddressAsync(user);
            return new SuccessDataResult<List<UserForAddressDto>>(userForAddressDtos, Messages.SuccessGet);
        }

        public async Task<IDataResult<List<User>>> GetListAsync()
        {
            List<User> users = await _userDal.GetAllAsync();
            return new SuccessDataResult<List<User>>(users, Messages.SuccessGet);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public async Task<IDataResult<User>> GetByMailAsync(string email)
        {
            User user = await _userDal.GetAsync(u => u.Email == email);
            return new SuccessDataResult<User>(user, Messages.SuccessGet);
        }

        [PerformanceAspect(5)]
        public async Task<IDataResult<List<Role>>> GetClaimsAsync(User user)
        {
            List<Role> roles = await _userDal.GetClaimsAsync(user);
            return new SuccessDataResult<List<Role>>(roles, Messages.SuccessGet);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public async Task<IDataResult<List<UserForCreditCardDto>>> GetListCreditCardsAsync(User user)
        {
            List<UserForCreditCardDto> userForCreditCardDtos = await _userDal.GetCrediCardsAsync(user);
            return new SuccessDataResult<List<UserForCreditCardDto>>(userForCreditCardDtos, Messages.SuccessGet);
        }
        [CacheRemoveAspect("IUserService.Get")]
        public async Task<IResult> UpdateAsync(User user)
        {
            await _userDal.UpdateAsync(user);
            return new SuccessResult();
        }

        public async Task<IResult> VerifyCodeAsync(VerifyCodeDto verifyCodeDto)
        {
            var getUserCode = await _userCodeService.GetByUserIdAsync(verifyCodeDto.UserId);
            if (getUserCode.Data.Code == verifyCodeDto.Code)
                return new SuccessResult();
            return new ErrorResult();
        }

        public async Task<IResult> SendCodeAsync(SendCodeDto sendCodeDto)
        {
            string code = new Random().Next(1000, 9999).ToString();
            var user = await GetByIdAsync(sendCodeDto.UserId);
            if (user.IsSuccess == false)
                return new ErrorResult(Messages.UserNotFound);

            var getUserCode = await _userCodeService.GetByUserIdAsync(sendCodeDto.UserId);
            if (getUserCode.IsSuccess == false)
            {
                await addUserCode(user.Data, code);
                return new SuccessResult();
            }
            await updateUserCode(user.Data, getUserCode.Data, code);

            return new SuccessResult();
        }
        private async Task addUserCode(User user, string code)
        {
            UserCode userCode = new UserCode
            {
                UserId = user.Id,
                Code = code
            };
            await _userCodeService.AddAsync(userCode);
            await SendEmailAsync(user, code);
        }
        private async Task updateUserCode(User user, UserCode userCode, string code)
        {
            userCode.Code = code;
            await SendEmailAsync(user, code);
            await _userCodeService.UpdateAsync(userCode);
        }
        private async Task SendEmailAsync(User user, string code)
        {
            await _emailService.SendEmailAsync(user.Email, Messages.SendCodeSubject, code);
        }

        public async Task<IResult> ResetPasswordAsync(ChangePasswordModel changePasswordModel)
        {
            IDataResult<User> user = await GetByIdAsync(changePasswordModel.UserId);
            if (HashingHelper.VerifyPasswordHash(changePasswordModel.OldPassword, user.Data.PasswordHash,
                user.Data.PasswordSalt) == false)
            {
                return new ErrorResult(Messages.WrongPassword);
            }

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(changePasswordModel.NewPassword, out passwordHash, out passwordSalt);

            user.Data.PasswordHash = passwordHash;
            user.Data.PasswordSalt = passwordSalt;

            IResult result = await UpdateAsync(user.Data);

            if (result.IsSuccess == false)
            {
                return new ErrorResult(result.Message);
            }
            return new SuccessResult(Messages.SuccessfulChangePassword);
        }
    }
}
