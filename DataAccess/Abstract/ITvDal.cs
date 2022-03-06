using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ITvDal:IEntityRepository<Tv>
    {
        Task<List<Photo>> GetPhotosAsync(int tvId);
        Task<List<TvAndPhotoDto>> GetTvWithPhotosAsync(Expression<Func<TvAndPhotoDto, bool>> filter=null);
        Task<List<TvAndPhotoDetailDto>> GetTvDetailsAsync(Expression<Func<TvAndPhotoDetailDto, bool>> filter = null);
        Task<TvAndPhotoDetailDto> GetTvDetailAsync(Expression<Func<TvAndPhotoDetailDto, bool>> filter);
    }
}
