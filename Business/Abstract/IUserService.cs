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
        Task<IDataResult<List<Role>>> GetClaims(User user);
        Task<IResult> Add(User user);
        Task<IResult> Update(User user);
        Task<IDataResult<User>> GetById(int userId);
        Task<IDataResult<User>> GetByKey(string key);
        Task<IResult> AddUserRole(User user);
        Task<IDataResult<User>> GetByMail(string email);
        Task<IDataResult<List<User>>> GetAll(); 

        Task<IDataResult<List<UserForAddressDto>>> GetAddress(User user);
        Task<IDataResult<List<UserForCreditCardDto>>> GetCreditCards(User user);
    }
}
