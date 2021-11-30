using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITvService
    {
        Task<IResult> Add(Tv entity);
        Task<IResult> Update(Tv entity);
        Task<IResult> Delete(Tv entity);
        Task<IDataResult<Tv>> Get(Expression<Func<Tv, bool>> filter);
        Task<IDataResult<List<Tv>>> GetByBrand(int brandId);
        Task<IDataResult<List<Tv>>> GetAll(Expression<Func<Tv, bool>> filter = null);
    }
}
