using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITvBrandService
    {
        Task<IResult> AddAsync(TvBrand entity);
        Task<IResult> UpdateAsync(TvBrand entity);
        Task<IResult> DeleteAsync(TvBrand entity);
        Task<IDataResult<TvBrand>> GetByIdAsync(int brandId);
        Task<IDataResult<List<TvBrand>>> GetListAsync();
        Task<IDataResult<List<CategoryWithCountDto>>> GetBrandsWithCountAsync();
        Task<IDataResult<List<CategoryWithPriceAverageDto>>> GetBrandsWithPriceAverageAsync();
    }
}
