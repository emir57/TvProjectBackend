using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, TvProjectContext>, IUserDal
    {
        public async Task<List<Role>> GetClaims(User user)
        {
            using(var context = new TvProjectContext())
            {
                var result = from roles in context.Roles
                             join userRoles in context.UserRoles
                             on roles.Id equals userRoles.RoleId
                             where userRoles.UserId == user.Id
                             select new Role
                             {
                                 Id = roles.Id,
                                 Name = roles.Name
                             };
                return await result.ToListAsync();
            }
        }
    }
}
