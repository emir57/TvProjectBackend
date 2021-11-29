using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserAddressManager : IUserAddressService
    {
        private readonly IUserAddressDal _userAddressDal;
        public UserAddressManager(IUserAddressDal userAddressDal)
        {
            _userAddressDal = userAddressDal;
        }
        public async Task<IResult> Add(UserAddress userAddress)
        {
            await _userAddressDal.Add(userAddress);
            return new SuccessResult(Messages.CreateUserAddress);
        }

        public async Task<IResult> Delete(UserAddress userAddress)
        {
            await _userAddressDal.Delete(userAddress);
            return new SuccessResult(Messages.DeleteUserAddress);
        }

        public async Task<IDataResult<UserAddress>> Get(Expression<Func<UserAddress, bool>> filter)
        {
            var result = await _userAddressDal.Get(filter);
            return new SuccessDataResult<UserAddress>(result);
        }

        public async Task<IDataResult<List<UserAddress>>> GetAll(Expression<Func<UserAddress, bool>> filter = null)
        {
            var result = filter == null ?
                await _userAddressDal.GetAll() :
                await _userAddressDal.GetAll(filter);
            return new SuccessDataResult<List<UserAddress>>(result);
        }

        public async Task<IDataResult<List<UserAddress>>> GetByUserId(int userId)
        {
            var result = await _userAddressDal.GetAll(u => u.UserId == userId);
            return new SuccessDataResult<List<UserAddress>>(result);
        }

        public async Task<IResult> Update(UserAddress userAddress)
        {
            await _userAddressDal.Update(userAddress);
            return new SuccessResult(Messages.UpdateUserAddress);
        }
    }
}
