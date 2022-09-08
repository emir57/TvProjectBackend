using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRoleDal : EfEntityRepositoryBase<Role, TvProjectContext>, IRoleDal
    {

        public async Task AddUserRoleAsync(User user, Role role)
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

        public async Task<UserRole> GetUserRoleAsync(Expression<Func<UserRole, bool>> filter)
        {
            using(var context = new TvProjectContext())
            {
                return await context.UserRoles.SingleOrDefaultAsync(filter);
            }
        }

        public async Task RemoveUserRoleAsync(User user, Role role)
        {
            using (var context = new TvProjectContext())
            {
                var userRole = await context.UserRoles.SingleOrDefaultAsync(x => x.RoleId == role.Id && x.UserId == user.Id);
                context.UserRoles.Remove(userRole);
                await context.SaveChangesAsync();
            }
        }
    }
}
