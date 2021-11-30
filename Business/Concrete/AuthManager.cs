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
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userDal;
        private readonly ITokenHelper _tokenHelper;
        
        public AuthManager(ITokenHelper tokenHelper, IUserService userDal)
        {
            _tokenHelper = tokenHelper;
            _userDal = userDal;
        }
        public async Task<IDataResult<AccessToken>> CreateAccessToken(User user)
        {
            var claims = await _userDal.GetClaims(user);
            var result = _tokenHelper.CreateToken(user,claims.Data);
            return new SuccessDataResult<AccessToken>(result, Messages.AccessTokenCreated);
        }
        [ValidationAspect(typeof(UserForLoginDtoValidator))]
        public async Task<IDataResult<User>> Login(UserForLoginDto userForLoginDto)
        {
            var result = await _userDal.GetByMail(userForLoginDto.Email);
            var user = result.Data;
            if (user == null)
            {
                new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                new ErrorDataResult<User>(Messages.WrongPassword);
            }
            return new SuccessDataResult<User>(user, Messages.SuccessfulLogin);
        }
        [ValidationAspect(typeof(UserForRegisterDtoValidator))]
        public async Task<IDataResult<User>> Register(UserForRegisterDto userForRegisterDto, string password)
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
            await _userDal.Add(user);
            return new SuccessDataResult<User>(user, Messages.SuccessfulRegister);

        }

        public async Task<IResult> UserExists(string email)
        {
            var result = await _userDal.GetByMail(email);
            if (result == null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.AlreadyUserExists);
        }
    }
}
