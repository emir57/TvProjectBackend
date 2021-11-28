using Core.DataAccess;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        Task<List<Role>> GetClaims(User user);
        Task<List<UserForAddressDto>> GetAddress(User user);
        Task<List<UserForCreditCardDto>> GetCrediCards(User user);
    }
}
