using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<List<Role>>> GetClaimsAsync(User user);
        Task<IResult> AddAsync(User user);
        Task<IResult> UpdateAsync(User user);
        Task<IDataResult<User>> GetByIdAsync(int userId);
        Task<IDataResult<User>> GetByKeyAsync(string key);
        Task<IResult> AddUserRoleAsync(User user);
        Task<IDataResult<User>> GetByMailAsync(string email);
        Task<IDataResult<List<User>>> GetListAsync(); 

        Task<IDataResult<List<UserForAddressDto>>> GetListAddressAsync(User user);
        Task<IDataResult<List<UserForCreditCardDto>>> GetListCreditCardsAsync(User user);
    }
}
