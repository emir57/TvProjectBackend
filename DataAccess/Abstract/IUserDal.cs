using Core.DataAccess;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        Task<List<Role>> GetClaimsAsync(User user);
        Task<List<UserForAddressDto>> GetAddressAsync(User user);
        Task<List<UserForCreditCardDto>> GetCrediCardsAsync(User user);
        Task AddUserRoleAsync(User user);
    }
}
