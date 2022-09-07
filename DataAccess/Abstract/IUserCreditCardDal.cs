using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserCreditCardDal:IEntityRepository<UserCreditCard>
    {
        Task AddUserCreditCardAsync(UserCreditCard userCreditCard);
        Task<List<CreditCardWithUserDto>> GetUserCreditCardsAsync(int userId);
    }
}
