using Core.Entities.Concrete;
using Core.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<List<Role>> GetClaims(User user);
        Task Add(User user);
        Task<User> GetByMail(string email);

        Task<List<UserForAddressDto>> GetAddress(User user);
        Task<List<UserForCreditCardDto>> GetCrediCards(User user);
    }
}
