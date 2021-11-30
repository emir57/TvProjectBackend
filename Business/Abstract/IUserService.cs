﻿using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<List<Role>>> GetClaims(User user);
        Task<IResult> Add(User user);
        Task<IDataResult<User>> GetByMail(string email);

        Task<IDataResult<List<UserForAddressDto>>> GetAddress(User user);
        Task<IDataResult<List<UserForCreditCardDto>>> GetCrediCards(User user);
    }
}