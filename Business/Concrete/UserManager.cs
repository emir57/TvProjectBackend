﻿using Business.Abstract;
using Core.Entities.Concrete;
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
        public async Task Add(User user)
        {
            await _userDal.Add(user);
        }

        public async Task<User> GetByMail(string email)
        {
            return await _userDal.Get(u => u.Email == email);
        }

        public async Task<List<Role>> GetClaims(User user)
        {
            return await _userDal.GetClaims(user);
        }
    }
}
