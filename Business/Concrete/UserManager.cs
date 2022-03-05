using Business.Abstract;
using Business.Constants;
using Business.Validators.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        [PerformanceAspect(3)]
        public async Task<IResult> AddAsync(User user)
        {
            await _userDal.AddAsync(user);
            return new SuccessResult(Messages.SuccessAdd);
        }

        public async Task<IResult> AddUserRoleAsync(User user)
        {
            await _userDal.AddUserRoleAsync(user);
            return new SuccessResult();
        }

        public async Task<IDataResult<User>> GetByIdAsync(int userId)
        {
            var result = await _userDal.GetAsync(x=>x.Id==userId);
            return new SuccessDataResult<User>(result);
        }
        public async Task<IDataResult<User>> GetByKeyAsync(string key)
        {
            var result = await _userDal.GetAsync(x => x.Key == key);
            return new SuccessDataResult<User>(result);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<IQueryable<UserForAddressDto>> GetListAddress(User user)
        {
            var result =  _userDal.GetAddress(user);
            return new SuccessDataResult<IQueryable<UserForAddressDto>>(result, Messages.SuccessGet);
        }

        public IDataResult<IQueryable<User>> GetList()
        {
            var result = _userDal.GetAll();
            return new SuccessDataResult<IQueryable<User>>(result, Messages.SuccessGet);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public async Task<IDataResult<User>> GetByMailAsync(string email)
        {
            var result = await _userDal.GetAsync(u => u.Email == email);
            return new SuccessDataResult<User>(result, Messages.SuccessGet);
        }
        
        [PerformanceAspect(5)]
        public IDataResult<IQueryable<Role>> GetClaims(User user)
        {
            var result = _userDal.GetClaims(user);
            return new SuccessDataResult<IQueryable<Role>>(result, Messages.SuccessGet);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<IQueryable<UserForCreditCardDto>> GetListCreditCards(User user)
        {
            var result = _userDal.GetCrediCards(user);
            return new SuccessDataResult<IQueryable<UserForCreditCardDto>>(result, Messages.SuccessGet);
        }
        [CacheRemoveAspect("IUserService.Get")]
        public async Task<IResult> UpdateAsync(User user)
        {
            await _userDal.UpdateAsync(user);
            return new SuccessResult();
        }
    }
}
