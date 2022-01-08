using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.Validators.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
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
        [SecuredOperation("User")]
        [ValidationAspect(typeof(UserAddressValidator))]
        [CacheRemoveAspect("IUserAddressService.Get")]
        [PerformanceAspect(3)]
        public async Task<IResult> Add(UserAddress userAddress)
        {
            await _userAddressDal.Add(userAddress);
            return new SuccessResult(Messages.CreateUserAddress);
        }
        [SecuredOperation("User")]
        [CacheRemoveAspect("IUserAddressService.Get")]
        [PerformanceAspect(3)]
        public async Task<IResult> Delete(UserAddress userAddress)
        {
            await _userAddressDal.Delete(userAddress);
            return new SuccessResult(Messages.DeleteUserAddress);
        }
        [SecuredOperation("User")]
        public async Task<IDataResult<UserAddress>> GetById(int addressId)
        {
            var result = await _userAddressDal.Get(x=>x.Id== addressId);
            return new SuccessDataResult<UserAddress>(result);
        }
        [SecuredOperation("User")]
        [CacheAspect]
        [PerformanceAspect(5)]
        public async Task<IDataResult<List<UserAddress>>> GetAll()
        {
            var result = await _userAddressDal.GetAll();
            return new SuccessDataResult<List<UserAddress>>(result);
        }

        public async Task<IDataResult<List<UserAddressCityDto>>> GetByCityName(int userId)
        {
            var result = await _userAddressDal.GetAddressByCityName(x=>x.UserId==userId);
            return new SuccessDataResult<List<UserAddressCityDto>>(result, Messages.SuccessGet);
        }

        [SecuredOperation("User")]
        [CacheAspect]
        [PerformanceAspect(5)]
        public async Task<IDataResult<List<UserAddress>>> GetByUserId(int userId)
        {
            var result = await _userAddressDal.GetAll(u => u.UserId == userId);
            return new SuccessDataResult<List<UserAddress>>(result);
        }
        [SecuredOperation("User")]
        [ValidationAspect(typeof(UserAddressValidator))]
        [CacheRemoveAspect("IUserAddressService.Get")]
        [PerformanceAspect(3)]
        public async Task<IResult> Update(UserAddress userAddress)
        {
            await _userAddressDal.Update(userAddress);
            return new SuccessResult(Messages.UpdateUserAddress);
        }
    }
}
