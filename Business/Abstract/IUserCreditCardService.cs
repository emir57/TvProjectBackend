using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserCreditCardService
    {
        Task<IResult> Add(UserCreditCard userCreditCard);
        Task<IResult> Delete(UserCreditCard userCreditCard);
        Task<IResult> Update(UserCreditCard userCreditCard);
        Task<IDataResult<List<UserCreditCard>>> GetByUserId(int userId);
        Task<IDataResult<List<UserCreditCard>>> GetAll();
        Task<IDataResult<UserCreditCard>> GetById(int creditCardId);
    }
}
