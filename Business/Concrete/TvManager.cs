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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TvManager:ITvService
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
        public async Task<IResult> Add(Tv entity)
        {
            var result = BusinessRules.Run(
                await CheckTvName(entity)
                );
            if (result != null)
            {
                return result;
            }
            await _tvDal.Add(entity);
            return new SuccessResult(Messages.SuccessAdd);
        }


        [SecuredOperation("Admin,Moderator")]
        [CacheRemoveAspect("ITvService.Get")]
        [PerformanceAspect(3)]
        public async Task<IResult> Delete(Tv entity)
        {
            await _tvDal.Delete(entity);
            return new SuccessResult(Messages.SuccessDelete);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public async Task<IDataResult<Tv>> Get(Expression<Func<Tv, bool>> filter)
        {
            var result = await _tvDal.Get(filter);
            return new SuccessDataResult<Tv>(result, Messages.SuccessGet);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public async Task<IDataResult<List<Tv>>> GetAll(Expression<Func<Tv, bool>> filter = null)
        {
            var result = filter == null ?
                await _tvDal.GetAll() :
                await _tvDal.GetAll(filter);

            //BusinessRules.Run(ApplyDiscount(result));
            return new SuccessDataResult<List<Tv>>(result, Messages.SuccessGet);
        }
        private IDataResult<List<Tv>> ApplyDiscount(List<Tv> products)
        {
            foreach (var product in products)
            {
                if (product.IsDiscount)
                {
                    product.UnitPrice = product.UnitPrice - (product.UnitPrice * product.Discount / 100);  
                }
            }
            return new SuccessDataResult<List<Tv>>(products);
        }

        public async Task<IDataResult<List<Tv>>> GetByBrand(int brandId)
        {
            var result = await _tvDal.GetAll(t => t.BrandId == brandId);
            return new SuccessDataResult<List<Tv>>(result, Messages.SuccessGet);
            
        }

        public async Task<IDataResult<List<Photo>>> GetPhotos(int tvId)
        {
            var result = await _tvDal.GetPhotos(tvId);
            return new SuccessDataResult<List<Photo>>(result,Messages.SuccessGet);
        }
        [SecuredOperation("Admin,Moderator")]
        [ValidationAspect(typeof(TvValidator))]
        [CacheRemoveAspect("ITvService.Get")]
        [PerformanceAspect(3)]
        public async Task<IResult> Update(Tv entity)
        {
            await _tvDal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdate);
        }

        public async Task<IDataResult<List<TvAndPhotoDto>>> GetTvWithPhotos(Expression<Func<TvAndPhotoDto, bool>> filter = null)
        {
            var result = filter == null ?
                await _tvDal.GetTvWithPhotos() :
                await _tvDal.GetTvWithPhotos(filter);
            return new SuccessDataResult<List<TvAndPhotoDto>>(result,Messages.SuccessGet);
        }

        public async Task<IDataResult<List<TvAndPhotoDetailDto>>> GetTvDetails(Expression<Func<TvAndPhotoDetailDto, bool>> filter = null)
        {
            var result = filter == null ?
                await _tvDal.GetTvDetails() :
                await _tvDal.GetTvDetails(filter);
            return new SuccessDataResult<List<TvAndPhotoDetailDto>>(result, Messages.SuccessGet);
        }

        public async Task<IDataResult<TvAndPhotoDetailDto>> GetTvDetail(Expression<Func<TvAndPhotoDetailDto, bool>> filter)
        {
            var result = await _tvDal.GetTvDetail(filter);
            return new SuccessDataResult<TvAndPhotoDetailDto>(result, Messages.SuccessGet);

        }
        private async Task<IResult> CheckTvName(Tv entity)
        {
            var tvs = await _tvDal.GetAll();
            if(tvs.Any(x => x.ProductName == entity.ProductName))
            {
                return new ErrorResult(Messages.ProductAlreadyExists);
            }
            return new SuccessResult();
        }

        //public async Task<IDataResult<List<TvAndPhotoDto>>> GetTvWithPhotos(Expression<Func<TvAndPhotoDto, bool>> filter)
        //{
        //    var result = await _tvDal.GetTvWithPhotos(filter);
        //    return new SuccessDataResult<List<TvAndPhotoDto>>(result, Messages.SuccessGet);
        //}
    }
}
