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
        Task<IDataResult<List<Tv>>> GetListByBrandAsync(int brandId);
        Task<IDataResult<List<Tv>>> GetListAsync();

        Task<IDataResult<List<Photo>>> GetListPhotosAsync(int tvId);
        Task<DataResult<List<TvAndPhotoDto>>> GetListTvWithPhotosAsync();
        Task<IDataResult<List<TvAndPhotoDetailDto>>> GetListTvDetailsAsync();
        Task<IDataResult<List<TvAndPhotoDetailDto>>> GetListTvDetailsByCategoryIdAsync(int categoryId);
        Task<IDataResult<TvAndPhotoDetailDto>> GetTvDetailAsync(int tvId);
    }
}
