using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRoleDal:IEntityRepository<Role>
    {
        Task AddUserRoleAsync(User user, Role role);
        Task RemoveUserRoleAsync(User user, Role role);
        Task<UserRole> GetUserRoleAsync(Expression<Func<UserRole, bool>> filter);
    }
}
