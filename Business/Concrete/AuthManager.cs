using Business.Abstract;
using Business.Constants;
using Business.Validators.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Security.Hashing;
using Core.Security.JWT;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;
        
        public AuthManager(ITokenHelper tokenHelper, IUserService userService)
        {
            _tokenHelper = tokenHelper;
            _userService = userService;
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var result = _tokenHelper.CreateToken(user,claims.Data.ToList());
            return new SuccessDataResult<AccessToken>(result, Messages.AccessTokenCreated);
        }
        [ValidationAspect(typeof(UserForLoginDtoValidator))]
        public async Task<IDataResult<User>> LoginAsync(UserForLoginDto userForLoginDto)
        {
            var result = await _userService.GetByMailAsync(userForLoginDto.Email);
            var user = result.Data;
            if (user == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.WrongPassword);
            }
            return new SuccessDataResult<User>(user, Messages.SuccessfulLogin);
        }
        [ValidationAspect(typeof(UserForRegisterDtoValidator))]
        public async Task<IDataResult<User>> RegisterAsync(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                Email = userForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            await _userService.AddAsync(user);
            await _userService.AddUserRoleAsync(user);
            return new SuccessDataResult<User>(user, Messages.SuccessfulRegister);

        }

        public async Task<IResult> UserExistsAsync(string email)
        {
            var result = await _userService.GetByMailAsync(email);
            if (result.Data == null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.AlreadyUserExists);
        }
    }
}
