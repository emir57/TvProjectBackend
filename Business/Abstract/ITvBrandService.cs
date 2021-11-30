using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITvBrandService
    {
        Task<IResult> Add(TvBrand entity);
        Task<IResult> Update(TvBrand entity);
        Task<IResult> Delete(TvBrand entity);
        Task<IDataResult<TvBrand>> Get(Expression<Func<TvBrand, bool>> filter);
        Task<IDataResult<List<TvBrand>>> GetAll(Expression<Func<TvBrand, bool>> filter = null);
    }
}
