using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserCreditCardDal:IEntityRepository<UserCreditCard>
    {
        Task AddUserCreditCard(UserCreditCard userCreditCard);
    }
}
