using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ITvDal:IEntityRepository<Tv>
    {
        Task<List<Photo>> GetPhotos(int tvId);
        Task<List<TvAndPhotoDto>> GetTvWithPhotos();
        Task<List<TvAndPhotoDto>> GetTvWithPhotos(int categoryId);
        Task<TvAndPhotoDetailDto> GetTvDetails(int tvId);
    }
}
