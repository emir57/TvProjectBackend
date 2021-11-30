using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPhotoService
    {
        Task<IResult> Add(Photo entity);
        Task<IResult> Update(Photo entity);
        Task<IResult> Delete(Photo entity);
        Task<IDataResult<Photo>> Get(Expression<Func<Photo, bool>> filter);
        Task<IDataResult<List<Photo>>> GetAll(Expression<Func<Photo, bool>> filter = null);
    }
}
