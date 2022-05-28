using Business.Abstract;
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
                return new ErrorResult(Messages.FailDelete);
            await _userCodeDal.DeleteAsync(userCode);
            return new SuccessResult(Messages.SuccessDelete);
        }

        public async Task<IResult> DeleteByUserIdAsync(int userId)
        {
            var userCode = await _userCodeDal.GetAsync(x => x.UserId == userId);
            if (userCode == null)
                return new ErrorResult(Messages.FailDelete);
            await _userCodeDal.DeleteAsync(userCode);
            return new SuccessResult(Messages.SuccessDelete);
        }

        public async Task<IDataResult<UserCode>> GetByUserIdAysnc(int userId)
        {
            var userCode = await _userCodeDal.GetAsync(x => x.UserId == userId);
            if (userCode == null)
                return new ErrorDataResult<UserCode>(Messages.FailGet);
            return new SuccessDataResult<UserCode>(userCode, Messages.SuccessGet);
        }

        public Task<IResult> UpdateAsync(UserCode userCode)
        {
            throw new NotImplementedException();
        }
    }
}
