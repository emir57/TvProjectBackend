using Core.DataAccess;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        IQueryable<Role> GetClaims(User user);
        IQueryable<UserForAddressDto> GetAddress(User user);
        IQueryable<UserForCreditCardDto> GetCrediCards(User user);
        Task AddUserRoleAsync(User user);
    }
}
