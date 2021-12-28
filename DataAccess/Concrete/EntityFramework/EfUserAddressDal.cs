using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserAddressDal : EfEntityRepositoryBase<UserAddres, TvProjectContext>, IUserAddressDal
    {
        public async Task AddUserAddress(UserAddres userAddress)
        {
            using(var context = new TvProjectContext())
            {
                await context.UserAddresses.AddAsync(userAddress);
                await context.SaveChangesAsync();
            }
        }
    }
}
