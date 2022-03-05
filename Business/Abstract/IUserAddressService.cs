using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserAddressService 
    {
        Task<IResult> AddAsync(UserAddress userAddress);
        Task<IResult> DeleteAsync(UserAddress userAddress);
        Task<IResult> UpdateAsync(UserAddress userAddress);
        Task<IDataResult<List<UserAddress>>> GetByUserIdAsync(int userId);
        Task<IDataResult<List<UserAddress>>> GetListAsync();
        Task<IDataResult<UserAddress>> GetByIdAsync(int addressId);
        Task<IDataResult<List<UserAddressCityDto>>> GetListCityNameByUserIdAsync(int userId);

    }
}
