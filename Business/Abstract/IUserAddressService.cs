using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserAddressService 
    {
        Task<IResult> AddAsync(UserAddress userAddress);
        Task<IResult> DeleteAsync(UserAddress userAddress);
        Task<IResult> UpdateAsync(UserAddress userAddress);
        IDataResult<IQueryable<UserAddress>> GetByUserId(int userId);
        IDataResult<IQueryable<UserAddress>> GetList();
        Task<IDataResult<UserAddress>> GetByIdAsync(int addressId);
        IDataResult<IQueryable<UserAddressCityDto>> GetListCityNameByUserId(int userId);

    }
}
