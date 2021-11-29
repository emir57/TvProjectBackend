using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
    }
}
