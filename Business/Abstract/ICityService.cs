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
        Task<IResult> Add(City entity);
        Task<IResult> Update(City entity);
        Task<IResult> Delete(City entity);
        Task<IDataResult<City>> Get(Expression<Func<City, bool>> filter);
        Task<IDataResult<List<City>>> GetAll(Expression<Func<City, bool>> filter = null);
    }
}
