using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserAddresService 
    {
        Task<IResult> Add(UserAddres userAddress);
        Task<IResult> Delete(UserAddres userAddress);
        Task<IResult> Update(UserAddres userAddress);
        Task<IDataResult<List<UserAddres>>> GetByUserId(int userId);
        Task<IDataResult<List<UserAddres>>> GetAll(Expression<Func<UserAddres,bool>> filter=null);
        Task<IDataResult<UserAddres>> Get(Expression<Func<UserAddres,bool>> filter);

    }
}
