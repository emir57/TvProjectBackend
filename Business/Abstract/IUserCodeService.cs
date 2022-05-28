using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserCodeService
    {
        Task<IDataResult<UserCode>> GetByUserIdAysnc(int userId);
        Task<IResult> AddAsync(UserCode userCode);
        Task<IResult> DeleteAsync(UserCode userCode);
        Task<IResult> DeleteAsync(int userCodeId);
        Task<IResult> DeleteByUserIdAsync(int userId);
        Task<IResult> UpdateAsync(UserCode userCode);
    }
}
