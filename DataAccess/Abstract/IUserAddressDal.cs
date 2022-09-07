using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserAddressDal:IEntityRepository<UserAddress>
    {
        Task<List<UserAddressCityDto>> GetAddressByCityNameAsync(Expression<Func<UserAddressCityDto, bool>> filter);
    }
}
