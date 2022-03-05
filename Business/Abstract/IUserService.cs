using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<IQueryable<Role>> GetClaims(User user);
        Task<IResult> AddAsync(User user);
        Task<IResult> UpdateAsync(User user);
        Task<IDataResult<User>> GetByIdAsync(int userId);
        Task<IDataResult<User>> GetByKeyAsync(string key);
        Task<IResult> AddUserRoleAsync(User user);
        Task<IDataResult<User>> GetByMailAsync(string email);
        IDataResult<IQueryable<User>> GetList(); 

        IDataResult<IQueryable<UserForAddressDto>> GetListAddress(User user);
        IDataResult<IQueryable<UserForCreditCardDto>> GetListCreditCards(User user);
    }
}
