using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRoleDal : EfEntityRepositoryBase<Role, TvProjectContext>, IRoleDal
    {
        private readonly TvProjectContext _context;

        public EfRoleDal(TvProjectContext context)
        {
            _context = context;
        }

        public async Task AddUserRoleAsync(User user, Role role)
        {
                var userRole = new UserRole
                {
                    RoleId = role.Id,
                    UserId = user.Id
                };
                _context.UserRoles.Add(userRole);
                await _context.SaveChangesAsync();
        }

        public async Task<UserRole> GetUserRoleAsync(Expression<Func<UserRole, bool>> filter)
        {
                return await _context.UserRoles.SingleOrDefaultAsync(filter);
        }

        public async Task RemoveUserRoleAsync(User user, Role role)
        {
                var userRole = await _context.UserRoles.SingleOrDefaultAsync(x => x.RoleId == role.Id && x.UserId == user.Id);
                _context.UserRoles.Remove(userRole);
                await _context.SaveChangesAsync();
        }
    }
}
