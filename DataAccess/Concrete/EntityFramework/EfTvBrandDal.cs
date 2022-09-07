using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTvBrandDal : EfEntityRepositoryBase<TvBrand, TvProjectContext>, ITvBrandDal
    {
        public async Task<List<CategoryWithCountDto>> GetBrandsWithCountAsync()
        {
            using (var context = new TvProjectContext())
            {
                var result = from br in context.TvBrands
                             select new CategoryWithCountDto
                             {
                                 Name = br.Name,
                                 Count = context.Tvs.Where(t => t.BrandId == br.Id).Count()
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<CategoryWithPriceAverageDto>> GetBrandsWithPriceAverageAsync()
        {
            using (var context = new TvProjectContext())
            {
                var result = from br in context.TvBrands
                             select new CategoryWithPriceAverageDto
                             {
                                 Name = br.Name,
                                 PriceAverage = CalculateProductsPriceAverage(
                                     context.Tvs.Select(t => new { t.BrandId, t.UnitPrice })
                                     .Where(t => t.BrandId == br.Id)
                                     .Select(t => t.UnitPrice)
                                     .ToArray())
                             };
                return await result.ToListAsync();
            }
        }
        private static decimal CalculateProductsPriceAverage(decimal[] prices)
        {
            decimal total = 0;
            if (prices.Length == 0)
                return total;
            for (int i = 0; i < prices.Length; i++)
            {
                total += prices[i];
            }
            decimal result = total / prices.Length;
            return result;
        }
    }
}
