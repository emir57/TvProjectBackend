using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Core.Entities.Dtos;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, TvProjectContext>, IUserDal
    {
        public async Task AddUserRole(User user)
        {
            using (var context = new TvProjectContext())
            {
                var userRole = new UserRole
                {
                    RoleId = 3,
                    UserId = user.Id
                };
                context.UserRoles.Add(userRole);
                await context.SaveChangesAsync();
                
            }
        }

        public async Task<List<UserForAddressDto>> GetAddress(User user)
        {
            using(var context = new TvProjectContext())
            {
                var result = from address in context.UserAddresses
                             where address.UserId == user.Id
                             select new UserForAddressDto
                             {
                                 UserId = user.Id,
                                 AddressText = address.AddressText,
                                 CityId = address.CityId
                             };
                return await result.ToListAsync();
            }
        }

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

        public async Task<List<UserForCreditCardDto>> GetCrediCards(User user)
        {
            using(var context = new TvProjectContext())
            {
                var result = from card in context.UserCreditCards
                             where card.UserId == user.Id
                             select new UserForCreditCardDto
                             {
                                 UserId = user.Id,
                                 CreditCardNumber = card.CreditCardNumber,
                                 CVV = card.CVV,
                                 Date = card.Date
                             };
                return await result.ToListAsync();
            }
        }
    }
}
