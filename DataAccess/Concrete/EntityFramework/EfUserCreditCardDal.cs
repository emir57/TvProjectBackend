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
        public async Task AddUserCreditCard(UserCreditCard userCreditCard)
        {
            using (var context = new TvProjectContext())
            {
                await context.UserCreditCards.AddAsync(userCreditCard);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<CreditCardWithUserDto>> GetUserCreditCards(int userId)
        {
            using(var context = new TvProjectContext())
            {
                var result = from c in context.UserCreditCards
                             join u in context.Users
                             on c.UserId equals u.Id
                             where c.UserId == userId
                             select new CreditCardWithUserDto
                             {
                                 User = u,
                                 UserCreditCard = c
                             };
                return await result.ToListAsync();
            }
        }
    }
}
