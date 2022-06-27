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
using Microsoft.EntityFrameworkCore;
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
            IResult result = BusinessRules.Run(
                await CheckUserAddressCount6Async(userAddress.UserId)
                );
            if (result != null)
            {
                return result;
            }
            await _userAddressDal.AddAsync(userAddress);
            return new SuccessResult(Messages.CreateUserAddress);
        }

        private async Task<IResult> CheckUserAddressCount6Async(int userId)
        {
            List<UserAddress> addresses = await _userAddressDal.GetAllAsync(a => a.UserId == userId);
            if (addresses.Count >= 6)
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
            UserAddress userAddress = await _userAddressDal.GetAsync(x => x.Id == addressId);
            if (userAddress == null)
                return new ErrorDataResult<UserAddress>(Messages.AddressIsNotFound);
            return new SuccessDataResult<UserAddress>(userAddress);
        }
        [SecuredOperation("User")]
        [CacheAspect]
        [PerformanceAspect(5)]
        public async Task<IDataResult<List<UserAddress>>> GetListAsync()
        {
            List<UserAddress> userAddresses = await _userAddressDal.GetAllAsync();
            return new SuccessDataResult<List<UserAddress>>(userAddresses);
        }

        public async Task<IDataResult<List<UserAddressCityDto>>> GetListCityNameByUserIdAsync(int userId)
        {
            List<UserAddressCityDto> userAddressCityDtos = await _userAddressDal.GetAddressByCityNameAsync(x => x.UserId == userId);
            return new SuccessDataResult<List<UserAddressCityDto>>(userAddressCityDtos, Messages.SuccessGet);
        }

        [SecuredOperation("User")]
        [CacheAspect]
        [PerformanceAspect(5)]
        public async Task<IDataResult<List<UserAddress>>> GetByUserIdAsync(int userId)
        {
            List<UserAddress> userAddresses = await _userAddressDal.GetAllAsync(u => u.UserId == userId);
            return new SuccessDataResult<List<UserAddress>>(userAddresses, Messages.SuccessGet);
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
