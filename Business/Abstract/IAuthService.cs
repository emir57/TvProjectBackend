using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Security.JWT;
using Core.Utilities.Results;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<IDataResult<User>> RegisterAsync(UserForRegisterDto userForRegisterDto, string password);
        Task<IDataResult<User>> LoginAsync(UserForLoginDto userForLoginDto);
        Task<IResult> UserExistsAsync(string email);
        Task<IDataResult<AccessToken>> CreateAccessTokenAsync(User user);

        Task<IResult> ResetPasswordAsync(ResetPasswordModel resetPasswordModel);
    }
}
