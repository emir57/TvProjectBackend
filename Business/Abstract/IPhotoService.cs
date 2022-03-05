using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPhotoService
    {
        Task<IResult> AddAsync(Photo entity);
        Task<IResult> UpdateAsync(Photo entity);
        Task<IResult> DeleteAsync(Photo entity);
        Task<IDataResult<Photo>> GetByIdAsync(int photoId);
        Task<IDataResult<List<Photo>>> GetListAsync();
        Task<IDataResult<List<Photo>>> GetListByTvIdAsync(int tvId);
    }
}
