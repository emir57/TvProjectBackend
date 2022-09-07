using Core.Entities.Concrete;
using Core.Utilities.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRoleService
    {
        Task<IResult> AddAsync(Role entity);
        Task<IResult> UpdateAsync(Role entity);
        Task<IResult> DeleteAsync(Role entity);
        Task<IDataResult<Role>> GetByIdAsync(int roleId);
        Task<IDataResult<List<Role>>> GetListAsync();
        Task<IResult> AddUserRoleAsync(User user, Role role);
        Task<IResult> RemoveUserRoleAsync(User user, Role role);
    }
}
