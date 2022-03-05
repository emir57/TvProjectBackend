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
        IQueryable<Photo> GetPhotos(int tvId);
        IQueryable<TvAndPhotoDto> GetTvWithPhotos(Expression<Func<TvAndPhotoDto, bool>> filter=null);
        IQueryable<TvAndPhotoDetailDto> GetTvDetails(Expression<Func<TvAndPhotoDetailDto, bool>> filter = null);
        Task<TvAndPhotoDetailDto> GetTvDetailAsync(Expression<Func<TvAndPhotoDetailDto, bool>> filter);
    }
}
