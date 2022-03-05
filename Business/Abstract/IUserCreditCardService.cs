using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserCreditCardService
    {
        Task<IResult> AddAsync(UserCreditCard userCreditCard);
        Task<IResult> DeleteAsync(UserCreditCard userCreditCard);
        Task<IResult> UpdateAsync(UserCreditCard userCreditCard);
        Task<IDataResult<List<UserCreditCard>>> GetByUserIdAsync(int userId);
        Task<IDataResult<List<UserCreditCard>>> GetListAsync();
        Task<IDataResult<List<UserCreditCard>>> GetListByUserIdAsync(int userId);
        Task<IDataResult<UserCreditCard>> GetByIdAsync(int creditCardId);
        Task<IDataResult<List<CreditCardWithUserDto>>> GetUserCreditCardsAsync(int userId);
    }
}
