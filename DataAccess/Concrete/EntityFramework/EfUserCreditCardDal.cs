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
    public class EfUserCreditCardDal : EfEntityRepositoryBase<UserCreditCard, TvProjectContext>, IUserCreditCardDal
    {
        private readonly TvProjectContext _context;

        public EfUserCreditCardDal(TvProjectContext context)
        {
            _context = context;
        }

        public async Task AddUserCreditCardAsync(UserCreditCard userCreditCard)
        {
                await _context.UserCreditCards.AddAsync(userCreditCard);
                await _context.SaveChangesAsync();
        }

        public IQueryable<CreditCardWithUserDto> GetUserCreditCards(int userId)
        {
                var result = from c in _context.UserCreditCards
                             join u in _context.Users
                             on c.UserId equals u.Id
                             where c.UserId == userId
                             select new CreditCardWithUserDto
                             {
                                 CreditCardNumber = c.CreditCardNumber,
                                 CVV=c.CVV,
                                 Date=c.Date,
                                 Id=c.Id,
                                 FirstName=u.FirstName,
                                 LastName=u.LastName
                             };
                return result;
        }
    }
}
