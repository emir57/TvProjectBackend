using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.Validators.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TvManager : ITvService
    {
        private readonly ITvDal _tvDal;

        public TvManager(ITvDal tvDal)
        {
            _tvDal = tvDal;
        }
        [SecuredOperation("Admin,Moderator")]
        [ValidationAspect(typeof(TvValidator))]
        [CacheRemoveAspect("ITvService.Get")]
        [PerformanceAspect(3)]
        public async Task<IResult> AddAsync(Tv entity)
        {
            IResult result = BusinessRules.Run(
                await CheckTvNameAsync(entity)
                );
            if (result != null) return result;

            await _tvDal.AddAsync(entity);
            return new SuccessResult(Messages.SuccessAdd);
        }

        [SecuredOperation("Admin,Moderator")]
        [CacheRemoveAspect("ITvService.Get")]
        [PerformanceAspect(3)]
        public async Task<IResult> DeleteAsync(Tv entity)
        {
            await _tvDal.DeleteAsync(entity);
            return new SuccessResult(Messages.SuccessDelete);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public async Task<IDataResult<Tv>> GetByIdAsync(int tvId)
        {
            Tv tv = await _tvDal.GetAsync(x => x.Id == tvId);
            if (tv == null)
                return new ErrorDataResult<Tv>(Messages.TvNotFound);

            return new SuccessDataResult<Tv>(tv, Messages.SuccessGet);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public async Task<IDataResult<List<Tv>>> GetListAsync()
        {
            List<Tv> tvs = await _tvDal.GetAllAsync();
            return new SuccessDataResult<List<Tv>>(tvs, Messages.SuccessGet);
        }
        private IDataResult<List<Tv>> ApplyDiscount(List<Tv> products)
        {
            foreach (var product in products)
                if (product.IsDiscount)
                    product.UnitPrice = product.UnitPrice - (product.UnitPrice * product.Discount / 100);

            return new SuccessDataResult<List<Tv>>(products);
        }

        public async Task<IDataResult<List<Tv>>> GetListByBrandAsync(int brandId)
        {
            List<Tv> tvs = (await GetListAsync()).Data;
            tvs = tvs.Where(t => t.BrandId == brandId).ToList();
            return new SuccessDataResult<List<Tv>>(tvs, Messages.SuccessGet);

        }

        public async Task<IDataResult<List<Photo>>> GetListPhotosAsync(int tvId)
        {
            List<Photo> photos = await _tvDal.GetPhotosAsync(tvId);
            return new SuccessDataResult<List<Photo>>(photos, Messages.SuccessGet);
        }
        [SecuredOperation("Admin,Moderator")]
        [ValidationAspect(typeof(TvValidator))]
        [CacheRemoveAspect("ITvService.Get")]
        [PerformanceAspect(3)]
        public async Task<IResult> UpdateAsync(Tv entity)
        {
            await _tvDal.UpdateAsync(entity);
            return new SuccessResult(Messages.SuccessUpdate);
        }
        //[CacheAspect<DataResult<List<TvAndPhotoDto>>>]
        [CacheAspect]
        public async Task<DataResult<List<TvAndPhotoDto>>> GetListTvWithPhotosAsync()
        {
            List<TvAndPhotoDto> tvAndPhotoDtos = await _tvDal.GetTvWithPhotosAsync();
            return new SuccessDataResult<List<TvAndPhotoDto>>(tvAndPhotoDtos, Messages.SuccessGet);
        }
        [PerformanceAspect(5)]
        [CacheAspect]
        public async Task<IDataResult<List<TvAndPhotoDetailDto>>> GetListTvDetailsAsync()
        {
            List<TvAndPhotoDetailDto> tvAndPhotoDetailDtos = await _tvDal.GetTvDetailsAsync();
            return new SuccessDataResult<List<TvAndPhotoDetailDto>>(tvAndPhotoDetailDtos, Messages.SuccessGet);
        }

        public async Task<IDataResult<TvAndPhotoDetailDto>> GetTvDetailAsync(int tvId)
        {
            TvAndPhotoDetailDto tvAndPhotoDetailDto = await _tvDal.GetTvDetailAsync(x => x.Id == tvId);
            return new SuccessDataResult<TvAndPhotoDetailDto>(tvAndPhotoDetailDto, Messages.SuccessGet);

        }
        private async Task<IResult> CheckTvNameAsync(Tv entity)
        {
            List<Tv> tvs = await _tvDal.GetAllAsync();
            if (tvs.Any(x => x.ProductName == entity.ProductName))
                return new ErrorResult(Messages.ProductAlreadyExists);

            return new SuccessResult();
        }
        [PerformanceAspect(5)]
        [CacheAspect]
        public async Task<IDataResult<List<TvAndPhotoDetailDto>>> GetListTvDetailsByCategoryIdAsync(int categoryId)
        {
            List<TvAndPhotoDetailDto> tvAndPhotoDetailDtos = await _tvDal.GetTvDetailsAsync(x => x.BrandId == categoryId);
            return new SuccessDataResult<List<TvAndPhotoDetailDto>>(tvAndPhotoDetailDtos, Messages.SuccessGet);
        }
    }
}
