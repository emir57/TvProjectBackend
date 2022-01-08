using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserAddressService 
    {
        Task<IResult> Add(UserAddress userAddress);
        Task<IResult> Delete(UserAddress userAddress);
        Task<IResult> Update(UserAddress userAddress);
        Task<IDataResult<List<UserAddress>>> GetByUserId(int userId);
        Task<IDataResult<List<UserAddress>>> GetList();
        Task<IDataResult<UserAddress>> GetById(int addressId);
        Task<IDataResult<List<UserAddressCityDto>>> GetListCityNameByUserId(int userId);

    }
}
