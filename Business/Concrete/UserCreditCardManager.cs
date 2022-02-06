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
    public class UserCreditCardManager : IUserCreditCardService
    {
        private readonly IUserCreditCardDal _creditCardDal;

        public UserCreditCardManager(IUserCreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }
        [SecuredOperation("User")]
        [ValidationAspect(typeof(UserCreditCardValidator))]
        [CacheRemoveAspect("IUserCreditCardService.Get")]
        [PerformanceAspect(3)]
        public async Task<IResult> Add(UserCreditCard userCreditCard)
        {
            await _creditCardDal.Add(userCreditCard);
            return new SuccessResult(Messages.AddUserCreditCard);
        }
        [SecuredOperation("User")]
        [CacheRemoveAspect("IUserCreditCardService.Get")]
        [PerformanceAspect(3)]
        public async Task<IResult> Delete(UserCreditCard userCreditCard)
        {
            await _creditCardDal.Delete(userCreditCard);
            return new SuccessResult(Messages.DeleteUserCreditCard);
        }
        [SecuredOperation("User")]
        [CacheAspect]
        [PerformanceAspect(5)]
        public async Task<IDataResult<UserCreditCard>> GetById(int creditCardId)
        {
            var result = await _creditCardDal.Get(x=>x.Id== creditCardId);
            return new SuccessDataResult<UserCreditCard>(result);
        }
        [SecuredOperation("User")]
        [CacheAspect]
        [PerformanceAspect(5)]
        public async Task<IDataResult<List<UserCreditCard>>> GetList()
        {
            var result = await _creditCardDal.GetAll();
            return new SuccessDataResult<List<UserCreditCard>>(result);
        }
        [SecuredOperation("User")]
        [CacheAspect]
        [PerformanceAspect(5)]
        public async Task<IDataResult<List<UserCreditCard>>> GetListByUserId(int userId)
        {
            var result = await _creditCardDal.GetAll(x=>x.UserId==userId);
            return new SuccessDataResult<List<UserCreditCard>>(result);
        }
        [SecuredOperation("User")]
        [CacheAspect]
        [PerformanceAspect(5)]
        public async Task<IDataResult<List<UserCreditCard>>> GetByUserId(int userId)
        {
            var result = await _creditCardDal.GetAll(c => c.UserId == userId);
            return new SuccessDataResult<List<UserCreditCard>>(result);
        }
        [SecuredOperation("User")]
        [ValidationAspect(typeof(UserCreditCardValidator))]
        [CacheRemoveAspect("IUserCreditCardService.Get")]
        [PerformanceAspect(3)]
        public async Task<IResult> Update(UserCreditCard userCreditCard)
        {
            await _creditCardDal.Update(userCreditCard);
            return new SuccessResult(Messages.UpdateCreditCard);
        }
        [SecuredOperation("User")]
        [PerformanceAspect(3)]
        public async Task<IDataResult<List<CreditCardWithUserDto>>> GetUserCreditCards(int userId)
        {
            var result = await _creditCardDal.GetUserCreditCards(userId);
            return new SuccessDataResult<List<CreditCardWithUserDto>>(result);
        }
    }
}
