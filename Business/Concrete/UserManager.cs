﻿using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public async Task<IResult> Add(User user)
        {
            await _userDal.Add(user);
            return new SuccessResult(Messages.SuccessAdd);
        }

        public async Task<IDataResult<List<UserForAddressDto>>> GetAddress(User user)
        {
            var result =  await _userDal.GetAddress(user);
            return new SuccessDataResult<List<UserForAddressDto>>(result, Messages.SuccessGet);
        }

        public async Task<IDataResult<User>> GetByMail(string email)
        {
            var result = await _userDal.Get(u => u.Email == email);
            return new SuccessDataResult<User>(result, Messages.SuccessGet);
        }

        public async Task<IDataResult<List<Role>>> GetClaims(User user)
        {
            var result = await _userDal.GetClaims(user);
            return new SuccessDataResult<List<Role>>(result, Messages.SuccessGet);
        }

        public async Task<IDataResult<List<UserForCreditCardDto>>> GetCrediCards(User user)
        {
            var result = await _userDal.GetCrediCards(user);
            return new SuccessDataResult<List<UserForCreditCardDto>>(result, Messages.SuccessGet);
        }
    }
}
