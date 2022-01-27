using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRoleDal : EfEntityRepositoryBase<Role, TvProjectContext>, IRoleDal
    {
        public async Task AddUserRole(User user, Role role)
        {
            using(var context = new TvProjectContext())
            {
                var userRole = new UserRole
                {
                    RoleId = role.Id,
                    UserId = user.Id
                };
                context.UserRoles.Add(userRole);
                await context.SaveChangesAsync();
            }
        }
    }
}
