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
    public class UserCreditCardManager : IUserCreditCardService
    {
        private readonly IUserCreditCardDal _creditCardDal;

        public UserCreditCardManager(IUserCreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public async Task<IResult> Add(UserCreditCard userCreditCard)
        {
            await _creditCardDal.Add(userCreditCard);
            return new SuccessResult(Messages.AddUserCreditCard);
        }

        public async Task<IResult> Delete(UserCreditCard userCreditCard)
        {
            await _creditCardDal.Delete(userCreditCard);
            return new SuccessResult(Messages.DeleteUserCreditCard);
        }

        public async Task<IDataResult<UserCreditCard>> Get(Expression<Func<UserCreditCard, bool>> filter)
        {
            var result = await _creditCardDal.Get(filter);
            return new SuccessDataResult<UserCreditCard>(result);
        }

        public async Task<IDataResult<List<UserCreditCard>>> GetAll(Expression<Func<UserCreditCard, bool>> filter = null)
        {
            var result = filter == null ?
                await _creditCardDal.GetAll() :
                await _creditCardDal.GetAll(filter);
            return new SuccessDataResult<List<UserCreditCard>>(result);
        }

        public async Task<IDataResult<List<UserCreditCard>>> GetByUserId(int userId)
        {
            var result = await _creditCardDal.GetAll(c => c.UserId == userId);
            return new SuccessDataResult<List<UserCreditCard>>(result);
        }

        public async Task<IResult> Update(UserCreditCard userCreditCard)
        {
            await _creditCardDal.Update(userCreditCard);
            return new SuccessResult(Messages.UpdateCreditCard);
        }
    }
}
