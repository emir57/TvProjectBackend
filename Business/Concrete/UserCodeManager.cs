﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserCodeManager : IUserCodeService
    {
        private readonly IUserCodeDal _userCodeDal;

        public UserCodeManager(IUserCodeDal userCodeDal)
        {
            _userCodeDal = userCodeDal;
        }

        public async Task<IResult> AddAsync(UserCode userCode)
        {
            await _userCodeDal.AddAsync(userCode);
            return new SuccessResult(Messages.SuccessAdd);
        }

        public async Task<IResult> DeleteAsync(UserCode userCode)
        {
            await _userCodeDal.DeleteAsync(userCode);
            return new SuccessResult(Messages.SuccessDelete);
        }

        public async Task<IResult> DeleteAsync(int userCodeId)
        {
            var userCode = await _userCodeDal.GetAsync(x => x.Id == userCodeId);
            if (userCode == null)
                return new ErrorResult(Messages.;
            await _userCodeDal.DeleteAsync(userCode);
            return new SuccessResult(Messages.SuccessDelete);
        }

        public Task<IResult> DeleteByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<UserCode>> GetByUserIdAysnc(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateAsync(UserCode userCode)
        {
            throw new NotImplementedException();
        }
    }
}
