using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, TvProjectContext>, IOrderDal
    {
        public Task<OrderDto> GetOrderByUserId(int userId)
        {
            using(var context = new TvProjectContext())
            {
                var result = from o in context.Orders
                             join u in context.Users
                             on o.UserId equals u.Id
                             join t in context.Tvs
                             on o.TvId equals t.Id
                             join a in context.UserAddresses
                             on o.AddressId equals a.Id
                             join c in context.
                               
            }
        }
    }
}
