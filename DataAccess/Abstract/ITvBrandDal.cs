using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ITvBrandDal:IEntityRepository<TvBrand>
    {
        Task<List<CategoryWithCountDto>> GetBrandsWithCountAsync();
        Task<List<CategoryWithPriceAverageDto>> GetBrandsWithPriceAverageAsync();
    }
}
