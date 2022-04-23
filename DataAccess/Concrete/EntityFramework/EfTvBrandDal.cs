using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
    }
}
