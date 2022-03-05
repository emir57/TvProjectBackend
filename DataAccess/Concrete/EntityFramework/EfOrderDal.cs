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
        private readonly TvProjectContext _context;

        public EfOrderDal(TvProjectContext context)
        {
            _context = context;
        }

        public IQueryable<OrderDto> GetOrdersByUserId(int userId)
        {
                var result = from o in _context.Orders
                             join u in _context.Users
                             on o.UserId equals u.Id
                             join t in _context.Tvs
                             on o.TvId equals t.Id
                             join a in _context.UserAddresses
                             on o.AddressId equals a.Id
                             join c in _context.Cities
                             on a.CityId equals c.Id
                             select new OrderDto
                             {
                                 Id = o.Id,
                                 TotalPrice = o.TotalPrice,
                                 ShippedDate = o.ShippedDate,
                                 User = u,
                                 AddressText = a.AddressText,
                                 City = c.CityName,
                                 Tv = new TvAndPhotoDto
                                 {
                                     Id = t.Id,
                                     ImageUrl = _context.Photos.SingleOrDefault(x => x.Id == t.Id && x.IsMain == true).ImageUrl,
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
                return result.Where(x => x.User.Id == userId);
        }

        public IQueryable<OrderDto> GetAllOrdersDto(Expression<Func<OrderDto, bool>> filter = null)
        {
                var result = from o in _context.Orders
                             join u in _context.Users
                             on o.UserId equals u.Id
                             join t in _context.Tvs
                             on o.TvId equals t.Id
                             join a in _context.UserAddresses
                             on o.AddressId equals a.Id
                             join c in _context.Cities
                             on a.CityId equals c.Id
                             select new OrderDto
                             {
                                 Id = o.Id,
                                 TotalPrice = o.TotalPrice,
                                 ShippedDate = o.ShippedDate,
                                 User = u,
                                 AddressText = a.AddressText,
                                 City = c.CityName,
                                 Tv = new TvAndPhotoDto
                                 {
                                     Id = t.Id,
                                     ImageUrl = _context.Photos.SingleOrDefault(x => x.Id == t.Id && x.IsMain == true).ImageUrl,
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
                    result:
                    result.Where(filter);
        }
    }
}
