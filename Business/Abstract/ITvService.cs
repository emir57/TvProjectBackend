using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
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
        Task<IDataResult<Tv>> GetById(int id);
        Task<IDataResult<List<Tv>>> GetByBrand(int brandId);
        Task<IDataResult<List<Tv>>> GetAll();

        Task<IDataResult<List<Photo>>> GetPhotos(int tvId);
        Task<IDataResult<List<TvAndPhotoDto>>> GetTvWithPhotos();
        Task<IDataResult<List<TvAndPhotoDetailDto>>> GetTvDetails();
        Task<IDataResult<List<TvAndPhotoDetailDto>>> GetTvDetailsByCategoryId(int categoryId);
        Task<IDataResult<TvAndPhotoDetailDto>> GetTvDetail(int id);
    }
}
