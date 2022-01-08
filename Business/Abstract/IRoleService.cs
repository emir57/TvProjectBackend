using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRoleService
    {
        Task<IResult> Add(Role entity);
        Task<IResult> Update(Role entity);
        Task<IResult> Delete(Role entity);
        Task<IDataResult<Role>> GetById(int roleId);
        Task<IDataResult<List<Role>>> GetAll();
    }
}
