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
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IResult> AddAsync(UserCreditCard userCreditCard)
        {
            await _creditCardDal.AddAsync(userCreditCard);
            return new SuccessResult(Messages.AddUserCreditCard);
        }
        [SecuredOperation("User")]
        [CacheRemoveAspect("IUserCreditCardService.Get")]
        [PerformanceAspect(3)]
        public async Task<IResult> DeleteAsync(UserCreditCard userCreditCard)
        {
            await _creditCardDal.DeleteAsync(userCreditCard);
            return new SuccessResult(Messages.DeleteUserCreditCard);
        }
        [SecuredOperation("User")]
        [CacheAspect]
        [PerformanceAspect(5)]
        public async Task<IDataResult<UserCreditCard>> GetByIdAsync(int creditCardId)
        {
            UserCreditCard userCreditCard = await _creditCardDal.GetAsync(x => x.Id == creditCardId);
            return new SuccessDataResult<UserCreditCard>(userCreditCard, Messages.SuccessGet);
        }
        [SecuredOperation("User")]
        [CacheAspect]
        [PerformanceAspect(5)]
        public async Task<IDataResult<List<UserCreditCard>>> GetListAsync()
        {
            List<UserCreditCard> userCreditCards = await _creditCardDal.GetAllAsync();
            return new SuccessDataResult<List<UserCreditCard>>(userCreditCards, Messages.SuccessGet);
        }
        [SecuredOperation("User")]
        [CacheAspect]
        [PerformanceAspect(5)]
        public async Task<IDataResult<List<UserCreditCard>>> GetListByUserIdAsync(int userId)
        {
            List<UserCreditCard> userCreditCards = await _creditCardDal.GetAllAsync(x => x.UserId == userId);
            return new SuccessDataResult<List<UserCreditCard>>(userCreditCards, Messages.SuccessGet);
        }
        [SecuredOperation("User")]
        [CacheAspect]
        [PerformanceAspect(5)]
        public async Task<IDataResult<List<UserCreditCard>>> GetByUserIdAsync(int userId)
        {
            List<UserCreditCard> userCreditCards = await _creditCardDal.GetAllAsync(c => c.UserId == userId);
            return new SuccessDataResult<List<UserCreditCard>>(userCreditCards, Messages.SuccessGet);
        }
        [SecuredOperation("User")]
        [ValidationAspect(typeof(UserCreditCardValidator))]
        [CacheRemoveAspect("IUserCreditCardService.Get")]
        [PerformanceAspect(3)]
        public async Task<IResult> UpdateAsync(UserCreditCard userCreditCard)
        {
            await _creditCardDal.UpdateAsync(userCreditCard);
            return new SuccessResult(Messages.UpdateCreditCard);
        }
        [SecuredOperation("User")]
        [PerformanceAspect(3)]
        public async Task<IDataResult<List<CreditCardWithUserDto>>> GetUserCreditCardsAsync(int userId)
        {
            List<CreditCardWithUserDto> creditCardWithUserDtos = await _creditCardDal.GetUserCreditCardsAsync(userId);
            return new SuccessDataResult<List<CreditCardWithUserDto>>(creditCardWithUserDtos, Messages.SuccessGet);
        }
    }
}
