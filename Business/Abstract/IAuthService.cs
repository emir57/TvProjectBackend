using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Security.JWT;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<IDataResult<User>> RegisterAsync(UserForRegisterDto userForRegisterDto, string password);
        Task<IDataResult<User>> LoginAsync(UserForLoginDto userForLoginDto);
        Task<IResult> UserExistsAsync(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
