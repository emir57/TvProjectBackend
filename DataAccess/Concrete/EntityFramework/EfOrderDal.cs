using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, TvProjectContext>, IOrderDal
    {
        public async Task<List<OrderDto>> GetOrdersByUserId(int userId)
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
                             join c in context.Cities
                             on a.CityId equals c.Id
                             select new OrderDto
                             {
                                 TotalPrice = o.TotalPrice,
                                 ShippedDate = o.ShippedDate,
                                 User = u,
                                 AddressText=a.AddressText,
                                 City=c.CityName,
                                 Tv=t
                             };
                return await result.Where(x => x.User.Id == userId).ToListAsync();            }
        }
    }
}
