using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITvService
    {
        Task<IResult> AddAsync(Tv entity);
        Task<IResult> UpdateAsync(Tv entity);
        Task<IResult> DeleteAsync(Tv entity);
        Task<IDataResult<Tv>> GetByIdAsync(int tvId);
        IDataResult<IQueryable<Tv>> GetListByBrand(int brandId);
        IDataResult<IQueryable<Tv>> GetList();

        IDataResult<IQueryable<Photo>> GetListPhotos(int tvId);
        IDataResult<IQueryable<TvAndPhotoDto>> GetListTvWithPhotos();
        IDataResult<List<TvAndPhotoDetailDto>> GetListTvDetails();
        IDataResult<IQueryable<TvAndPhotoDetailDto>> GetListTvDetailsByCategoryId(int categoryId);
        Task<IDataResult<TvAndPhotoDetailDto>> GetTvDetailAsync(int tvId);
    }
}
