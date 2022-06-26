using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.Validators.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TvBrandManager : ITvBrandService
    {
        private readonly ITvBrandDal _tvBrandDal;

        public TvBrandManager(ITvBrandDal tvBrandDal)
        {
            _tvBrandDal = tvBrandDal;
        }
        [SecuredOperation("Admin,Moderator")]
        [ValidationAspect(typeof(TvBrandValidator))]
        [CacheRemoveAspect("ITvBrandService.Get")]
        [PerformanceAspect(3)]
        public async Task<IResult> AddAsync(TvBrand entity)
        {
            await _tvBrandDal.AddAsync(entity);
            return new SuccessResult(Messages.SuccessAdd);
        }
        [SecuredOperation("Admin,Moderator")]
        [CacheRemoveAspect("ITvBrandService.Get")]
        [PerformanceAspect(3)]
        public async Task<IResult> DeleteAsync(TvBrand entity)
        {
            await _tvBrandDal.DeleteAsync(entity);
            return new SuccessResult(Messages.SuccessDelete);
        }

        public async Task<IDataResult<List<CategoryWithCountDto>>> GetBrandsWithCountAsync()
        {
            List<CategoryWithCountDto> brandsWithCount = await _tvBrandDal.GetBrandsWithCountAsync();
            return new SuccessDataResult<List<CategoryWithCountDto>>(brandsWithCount, Messages.SuccessGet);
        }

        public async Task<IDataResult<List<CategoryWithPriceAverageDto>>> GetBrandsWithPriceAverageAsync()
        {
            List<CategoryWithPriceAverageDto> brandsWithPriceAverage = await _tvBrandDal.GetBrandsWithPriceAverageAsync();
            return new SuccessDataResult<List<CategoryWithPriceAverageDto>>(brandsWithPriceAverage, Messages.SuccessGet);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public async Task<IDataResult<TvBrand>> GetByIdAsync(int brandId)
        {
            TvBrand tvBrand = await _tvBrandDal.GetAsync(x => x.Id == brandId);
            if (tvBrand == null)
                return new ErrorDataResult<TvBrand>(Messages.TvBrandNotFound);
            return new SuccessDataResult<TvBrand>(tvBrand, Messages.SuccessGet);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public async Task<IDataResult<List<TvBrand>>> GetListAsync()
        {
            List<TvBrand> tvBrands = await _tvBrandDal.GetAllAsync();
            return new SuccessDataResult<List<TvBrand>>(tvBrands, Messages.SuccessGet);
        }
        [SecuredOperation("Admin,Moderator")]
        [ValidationAspect(typeof(TvBrandValidator))]
        [CacheRemoveAspect("ITvBrandService.Get")]
        [PerformanceAspect(3)]
        public async Task<IResult> UpdateAsync(TvBrand entity)
        {
            await _tvBrandDal.UpdateAsync(entity);
            return new SuccessResult(Messages.SuccessUpdate);
        }
    }
}
