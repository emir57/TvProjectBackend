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
        private readonly TvProjectContext _context;

        public EfUserDal(TvProjectContext context)
        {
            _context = context;
        }

        public async Task AddUserRoleAsync(User user)
        {
                var userRole = new UserRole
                {
                    RoleId = 3,
                    UserId = user.Id
                };
                _context.UserRoles.Add(userRole);
                await _context.SaveChangesAsync();
        }

        public IQueryable<UserForAddressDto> GetAddress(User user)
        {
                var result = from address in _context.UserAddresses
                             where address.UserId == user.Id
                             select new UserForAddressDto
                             {
                                 UserId = user.Id,
                                 AddressText = address.AddressText,
                                 CityId = address.CityId
                             };
                return result;
        }

        public IQueryable<Role> GetClaims(User user)
        {
                var result = from roles in _context.Roles
                             join userRoles in _context.UserRoles
                             on roles.Id equals userRoles.RoleId
                             where userRoles.UserId == user.Id
                             select new Role
                             {
                                 Id = roles.Id,
                                 Name = roles.Name
                             };
                return result;
        }

        public IQueryable<UserForCreditCardDto> GetCrediCards(User user)
        {
                var result = from card in _context.UserCreditCards
                             where card.UserId == user.Id
                             select new UserForCreditCardDto
                             {
                                 UserId = user.Id,
                                 CreditCardNumber = card.CreditCardNumber,
                                 CVV = card.CVV,
                                 Date = card.Date
                             };
                return result;
        }
    }
}
