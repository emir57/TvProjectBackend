﻿using Business.Abstract;
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
            await _userDal.Add(user);
            return new SuccessResult(Messages.SuccessAdd);
        }

        public async Task<IResult> AddUserRoleAsync(User user)
        {
            await _userDal.AddUserRoleAsync(user);
            return new SuccessResult();
        }

        public async Task<IDataResult<User>> GetByIdAsync(int userId)
        {
            var result = await _userDal.Get(x=>x.Id==userId);
            return new SuccessDataResult<User>(result);
        }
        public async Task<IDataResult<User>> GetByKeyAsync(string key)
        {
            var result = await _userDal.Get(x => x.Key == key);
            return new SuccessDataResult<User>(result);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public async Task<IDataResult<List<UserForAddressDto>>> GetListAddressAsync(User user)
        {
            var result =  await _userDal.GetAddressAsync(user);
            return new SuccessDataResult<List<UserForAddressDto>>(result, Messages.SuccessGet);
        }

        public async Task<IDataResult<List<User>>> GetListAsync()
        {
            var result = await _userDal.GetAll();
            return new SuccessDataResult<List<User>>(result, Messages.SuccessGet);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public async Task<IDataResult<User>> GetByMailAsync(string email)
        {
            var result = await _userDal.Get(u => u.Email == email);
            return new SuccessDataResult<User>(result, Messages.SuccessGet);
        }
        
        [PerformanceAspect(5)]
        public async Task<IDataResult<List<Role>>> GetClaimsAsync(User user)
        {
            var result = await _userDal.GetClaimsAsync(user);
            return new SuccessDataResult<List<Role>>(result, Messages.SuccessGet);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public async Task<IDataResult<List<UserForCreditCardDto>>> GetListCreditCardsAsync(User user)
        {
            var result = await _userDal.GetCrediCardsAsync(user);
            return new SuccessDataResult<List<UserForCreditCardDto>>(result, Messages.SuccessGet);
        }
        [CacheRemoveAspect("IUserService.Get")]
        public async Task<IResult> UpdateAsync(User user)
        {
            await _userDal.Update(user);
            return new SuccessResult();
        }
    }
}
