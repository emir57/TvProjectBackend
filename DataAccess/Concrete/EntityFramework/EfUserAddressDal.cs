using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserAddressDal : EfEntityRepositoryBase<UserAddress, TvProjectContext>, IUserAddressDal
    {
        
    }
}
