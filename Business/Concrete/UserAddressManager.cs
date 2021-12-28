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
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserAddressManager : IUserAddresService
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
        public async Task<IResult> Add(UserAddres userAddress)
        {
            await _userAddressDal.Add(userAddress);
            return new SuccessResult(Messages.CreateUserAddress);
        }
        [SecuredOperation("User")]
        [CacheRemoveAspect("IUserAddressService.Get")]
        [PerformanceAspect(3)]
        public async Task<IResult> Delete(UserAddres userAddress)
        {
            await _userAddressDal.Delete(userAddress);
            return new SuccessResult(Messages.DeleteUserAddress);
        }
        [SecuredOperation("User")]
        public async Task<IDataResult<UserAddres>> Get(Expression<Func<UserAddres, bool>> filter)
        {
            var result = await _userAddressDal.Get(filter);
            return new SuccessDataResult<UserAddres>(result);
        }
        [SecuredOperation("User")]
        [CacheAspect]
        [PerformanceAspect(5)]
        public async Task<IDataResult<List<UserAddres>>> GetAll(Expression<Func<UserAddres, bool>> filter = null)
        {
            var result = filter == null ?
                await _userAddressDal.GetAll() :
                await _userAddressDal.GetAll(filter);
            return new SuccessDataResult<List<UserAddres>>(result);
        }
        [SecuredOperation("User")]
        [CacheAspect]
        [PerformanceAspect(5)]
        public async Task<IDataResult<List<UserAddres>>> GetByUserId(int userId)
        {
            var result = await _userAddressDal.GetAll(u => u.UserId == userId);
            return new SuccessDataResult<List<UserAddres>>(result);
        }
        [SecuredOperation("User")]
        [ValidationAspect(typeof(UserAddressValidator))]
        [CacheRemoveAspect("IUserAddressService.Get")]
        [PerformanceAspect(3)]
        public async Task<IResult> Update(UserAddres userAddress)
        {
            await _userAddressDal.Update(userAddress);
            return new SuccessResult(Messages.UpdateUserAddress);
        }
    }
}
