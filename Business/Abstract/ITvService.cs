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
        Task<IDataResult<Tv>> GetById(int tvId);
        Task<IDataResult<List<Tv>>> GetListByBrand(int brandId);
        Task<IDataResult<List<Tv>>> GetList();

        Task<IDataResult<List<Photo>>> GetListPhotos(int tvId);
        Task<IDataResult<List<TvAndPhotoDto>>> GetListTvWithPhotos();
        Task<IDataResult<List<TvAndPhotoDetailDto>>> GetListTvDetails(int page);
        Task<IDataResult<List<TvAndPhotoDetailDto>>> GetListTvDetailsByCategoryId(int categoryId);
        Task<IDataResult<TvAndPhotoDetailDto>> GetTvDetail(int tvId);
    }
}
