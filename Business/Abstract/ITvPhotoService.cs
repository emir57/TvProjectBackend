using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITvPhotoService
    {
        Task<IResult> Add(TvPhoto entity);
        Task<IResult> Update(TvPhoto entity);
        Task<IResult> Delete(TvPhoto entity);
        Task<IDataResult<TvPhoto>> Get(Expression<Func<TvPhoto, bool>> filter);
        Task<IDataResult<List<TvPhoto>>> GetAll(Expression<Func<TvPhoto, bool>> filter = null);
    }
}
