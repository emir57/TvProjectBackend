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
        public async Task<IResult> Add(User user)
        {
            await _userDal.Add(user);
            return new SuccessResult(Messages.SuccessAdd);
        }

        public async Task<IResult> AddUserRole(User user)
        {
            await _userDal.AddUserRole(user);
            return new SuccessResult();
        }

        public async Task<IDataResult<User>> Get(Expression<Func<User, bool>> filter)
        {
            var result = await _userDal.Get(filter);
            return new SuccessDataResult<User>(result);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public async Task<IDataResult<List<UserForAddressDto>>> GetAddress(User user)
        {
            var result =  await _userDal.GetAddress(user);
            return new SuccessDataResult<List<UserForAddressDto>>(result, Messages.SuccessGet);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public async Task<IDataResult<User>> GetByMail(string email)
        {
            var result = await _userDal.Get(u => u.Email == email);
            return new SuccessDataResult<User>(result, Messages.SuccessGet);
        }
        
        [PerformanceAspect(5)]
        public async Task<IDataResult<List<Role>>> GetClaims(User user)
        {
            var result = await _userDal.GetClaims(user);
            return new SuccessDataResult<List<Role>>(result, Messages.SuccessGet);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public async Task<IDataResult<List<UserForCreditCardDto>>> GetCreditCards(User user)
        {
            var result = await _userDal.GetCrediCards(user);
            return new SuccessDataResult<List<UserForCreditCardDto>>(result, Messages.SuccessGet);
        }
        [CacheRemoveAspect("IUserService.Get")]
        public async Task<IResult> Update(User user)
        {
            await _userDal.Update(user);
            return new SuccessResult();
        }
    }
}
