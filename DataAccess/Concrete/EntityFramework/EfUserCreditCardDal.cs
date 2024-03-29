﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Contexts;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserCreditCardDal : EfEntityRepositoryBase<UserCreditCard, TvProjectContext>, IUserCreditCardDal
    {
        public async Task AddUserCreditCardAsync(UserCreditCard userCreditCard)
        {
            using(var context = new TvProjectContext())
            {
                await context.UserCreditCards.AddAsync(userCreditCard);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<CreditCardWithUserDto>> GetUserCreditCardsAsync(int userId)
        {
            using (var context = new TvProjectContext())
            {
                var result = from c in context.UserCreditCards
                             join u in context.Users
                             on c.UserId equals u.Id
                             where c.UserId == userId
                             select new CreditCardWithUserDto
                             {
                                 CreditCardNumber = c.CreditCardNumber,
                                 CVV = c.CVV,
                                 Date = c.Date,
                                 Id = c.Id,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName
                             };
                return await result.ToListAsync();
            }
        }
    }
}
