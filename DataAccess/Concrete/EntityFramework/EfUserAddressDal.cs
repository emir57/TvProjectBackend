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
        public async Task<List<UserAddressCityDto>> GetAddressByCityNameAsync(Expression<Func<UserAddressCityDto, bool>> filter)
        {
            using(var context = new TvProjectContext())
            {
                var result = from adress in context.UserAddresses
                             from city in context.Cities
                             where adress.CityId == city.Id && adress.DeletedDate != null
                             select new UserAddressCityDto
                             {
                                 Id = adress.Id,
                                 UserId = adress.UserId,
                                 AddressName = adress.AddressName,
                                 CityId = adress.CityId,
                                 AddressText = adress.AddressText,
                                 CityName = city.CityName
                             };
                return await result.Where(filter).ToListAsync();
            }
        }
    }
}
