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
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, TvProjectContext>, IOrderDal
    {
        public async Task<List<OrderDto>> GetOrdersByUserIdAsync(int userId)
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
                                 Id = o.Id,
                                 TotalPrice = o.TotalPrice,
                                 ShippedDate = o.ShippedDate,
                                 User = u,
                                 AddressText = a.AddressText,
                                 City = c.CityName,
                                 Tv = new TvAndPhotoDetailDto
                                 {
                                     Id = t.Id,
                                     Photos = context.Photos.Where(x => x.Id == t.Id).ToList(),
                                     Discount = t.Discount,
                                     IsDiscount = t.IsDiscount,
                                     ProductCode = t.ProductCode,
                                     Stock = t.Stock,
                                     UnitPrice = t.UnitPrice,
                                     Extras = t.Extras,
                                     ScreenType = t.ScreenType,
                                     ProductName = t.ProductName,
                                     ScreenInch = t.ScreenInch
                                 }
                             };
                return await result.Where(x => x.User.Id == userId).ToListAsync();
            }
        }

        public async Task<List<OrderDto>> GetAllOrdersDtoAsync(Expression<Func<OrderDto, bool>> filter = null)
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
                                 Id = o.Id,
                                 TotalPrice = o.TotalPrice,
                                 ShippedDate = o.ShippedDate,
                                 User = u,
                                 AddressText = a.AddressText,
                                 City = c.CityName,
                                 Tv = new TvAndPhotoDetailDto
                                 {
                                     Id = t.Id,
                                     Photos = context.Photos.Where(x => x.Id == t.Id).ToList(),
                                     Discount = t.Discount,
                                     IsDiscount = t.IsDiscount,
                                     ProductCode = t.ProductCode,
                                     Stock = t.Stock,
                                     UnitPrice = t.UnitPrice,
                                     Extras = t.Extras,
                                     ScreenType = t.ScreenType,
                                     ProductName = t.ProductName,
                                     ScreenInch = t.ScreenInch
                                 }
                             };
                return filter == null ?
                    await result.ToListAsync() :
                    await result.Where(filter).ToListAsync();
            }
        }
    }
}
