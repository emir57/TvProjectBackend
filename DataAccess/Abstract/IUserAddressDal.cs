using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserAddressDal:IEntityRepository<UserAddress>
    {
        Task AddUserAddress(UserAddress userAddress);
    }
}
