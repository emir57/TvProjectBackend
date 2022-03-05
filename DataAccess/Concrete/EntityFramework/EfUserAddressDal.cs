using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserAddressDal : EfEntityRepositoryBase<UserAddress, TvProjectContext>, IUserAddressDal
    {
        private readonly TvProjectContext _context;

        public EfUserAddressDal(TvProjectContext context)
        {
            _context = context;
        }

        public IQueryable<UserAddressCityDto> GetAddressByCityName(Expression<Func<UserAddressCityDto, bool>> filter)
        {
                var result = from adress in _context.UserAddresses
                             from city in _context.Cities
                             where adress.CityId == city.Id
                             select new UserAddressCityDto
                             {
                                 Id = adress.Id,
                                 UserId = adress.UserId,
                                 AddressName=adress.AddressName,
                                 CityId = adress.CityId,
                                 AddressText = adress.AddressText,
                                 CityName = city.CityName
                             };
                return result.Where(filter);
        }
    }
}
