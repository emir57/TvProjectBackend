using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.Validators.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IResult> AddAsync(UserAddress userAddress)
        {
            var result = BusinessRules.Run(
                CheckUserAddressCount6(userAddress.UserId)
                );
            if (result != null)
            {
                return result;
            }
            await _userAddressDal.AddAsync(userAddress);
            return new SuccessResult(Messages.CreateUserAddress);
        }

        private IResult CheckUserAddressCount6(int userId)
        {
            var addresses = _userAddressDal.GetAll(a => a.UserId == userId);
            if (addresses.Count() >= 6)
            {
                return new ErrorResult(Messages.UserAddressMaximumCount6);
            }
            return new SuccessResult();
        }

        [SecuredOperation("User")]
        [CacheRemoveAspect("IUserAddressService.Get")]
        [PerformanceAspect(3)]
        public async Task<IResult> DeleteAsync(UserAddress userAddress)
        {
            await _userAddressDal.DeleteAsync(userAddress);
            return new SuccessResult(Messages.DeleteUserAddress);
        }
        [SecuredOperation("User")]
        public async Task<IDataResult<UserAddress>> GetByIdAsync(int addressId)
        {
            var result = await _userAddressDal.GetAsync(x=>x.Id== addressId);
            return new SuccessDataResult<UserAddress>(result);
        }
        [SecuredOperation("User")]
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<IQueryable<UserAddress>> GetList()
        {
            var result = _userAddressDal.GetAll();
            return new SuccessDataResult<IQueryable<UserAddress>>(result);
        }

        public IDataResult<IQueryable<UserAddressCityDto>> GetListCityNameByUserId(int userId)
        {
            var result = _userAddressDal.GetAddressByCityName(x=>x.UserId==userId);
            return new SuccessDataResult<IQueryable<UserAddressCityDto>>(result, Messages.SuccessGet);
        }

        [SecuredOperation("User")]
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<IQueryable<UserAddress>> GetByUserId(int userId)
        {
            var result = _userAddressDal.GetAll(u => u.UserId == userId);
            return new SuccessDataResult<IQueryable<UserAddress>>(result);
        }
        [SecuredOperation("User")]
        [ValidationAspect(typeof(UserAddressValidator))]
        [CacheRemoveAspect("IUserAddressService.Get")]
        [PerformanceAspect(3)]
        public async Task<IResult> UpdateAsync(UserAddress userAddress)
        {
            await _userAddressDal.UpdateAsync(userAddress);
            return new SuccessResult(Messages.UpdateUserAddress);
        }
    }
}
