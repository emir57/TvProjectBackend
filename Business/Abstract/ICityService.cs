using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICityService
    {
        Task<IResult> AddAsync(City entity);
        Task<IResult> UpdateAsync(City entity);
        Task<IResult> DeleteAsync(City entity);
        Task<IDataResult<City>> GetByIdAsync(int cityId);
        Task<IDataResult<List<City>>> GetListAsync();
    }
}
