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
        Task AddUserRole(User user, Role role);
        Task RemoveUserRole(User user, Role role);
        Task<UserRole> GetUserRole(Expression<Func<UserRole, bool>> filter);
    }
}
