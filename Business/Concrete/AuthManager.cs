using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.Validators.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Security.Hashing;
using Core.Security.JWT;
using Core.Utilities.Results;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;
        private readonly IMapper _mapper;
        public AuthManager(ITokenHelper tokenHelper, IUserService userService, IMapper mapper)
        {
            _tokenHelper = tokenHelper;
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<IDataResult<AccessToken>> CreateAccessTokenAsync(User user)
        {
            IDataResult<List<Role>> claims = await _userService.GetClaimsAsync(user);

            AccessToken token = _tokenHelper.CreateToken(user, claims.Data.ToList());

            return new SuccessDataResult<AccessToken>(token, Messages.AccessTokenCreated);
        }
        [ValidationAspect(typeof(UserForLoginDtoValidator))]
        public async Task<IDataResult<User>> LoginAsync(UserForLoginDto userForLoginDto)
        {
            IDataResult<User> userResult = await _userService.GetByMailAsync(userForLoginDto.Email);
            if (userResult.Data == null)
                return new ErrorDataResult<User>(Messages.UserNotFound);

            if (HashingHelper.VerifyPasswordHash(userForLoginDto.Password,
                    userResult.Data.PasswordHash,
                    userResult.Data.PasswordSalt) == false)
                return new ErrorDataResult<User>(Messages.WrongPassword);

            return new SuccessDataResult<User>(userResult.Data, Messages.SuccessfulLogin);
        }
        [ValidationAspect(typeof(UserForRegisterDtoValidator))]
        public async Task<IDataResult<User>> RegisterAsync(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;

            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            User user = _mapper.Map<User>(userForRegisterDto);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Status = true;

            await _userService.AddAsync(user);
            await _userService.AddUserRoleAsync(user);

            return new SuccessDataResult<User>(user, Messages.SuccessfulRegister);

        }

        public async Task<IResult> ResetPasswordAsync(ResetPasswordModel resetPasswordModel)
        {
            byte[] passwordHash, passwordSalt;

            IDataResult<User> getUser = await _userService.GetByKeyAsync(resetPasswordModel.Key);
            if (getUser.Data == null || getUser.Data.Key != resetPasswordModel.Key)
            {
                return new ErrorResult(Messages.InvalidKey);
            }
            if (!HashingHelper.VerifyPasswordHash(resetPasswordModel.OldPassword, getUser.Data.PasswordHash, getUser.Data.PasswordSalt))
            {
                return new ErrorResult(Messages.WrongOldPassword);
            }

            HashingHelper.CreatePasswordHash(resetPasswordModel.NewPassword, out passwordHash, out passwordSalt);
            getUser.Data.PasswordHash = passwordHash;
            getUser.Data.PasswordSalt = passwordSalt;
            getUser.Data.Key = "";
            await _userService.UpdateAsync(getUser.Data);

            return new SuccessResult(Messages.SuccessResetPassword);
        }

        public async Task<IResult> UserExistsAsync(string email)
        {
            IDataResult<User> result = await _userService.GetByMailAsync(email);
            if (result.Data == null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.AlreadyUserExists);
        }
    }
}
