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
        public async Task<IResult> AddAsync(Tv entity)
        {
            var result = BusinessRules.Run(
                CheckTvName(entity)
                );
            if (result != null)
            {
                return result;
            }
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
            var result = await _tvDal.GetAsync(x=>x.Id== tvId);
            return new SuccessDataResult<Tv>(result, Messages.SuccessGet);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<IQueryable<Tv>> GetList()
        {
            var result = _tvDal.GetAll();

            //BusinessRules.Run(ApplyDiscount(result));
            return new SuccessDataResult<IQueryable<Tv>>(result, Messages.SuccessGet);
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

        public IDataResult<IQueryable<Tv>> GetListByBrand(int brandId)
        {
            var result = _tvDal.GetAll(t => t.BrandId == brandId);
            return new SuccessDataResult<IQueryable<Tv>>(result, Messages.SuccessGet);
            
        }

        public IDataResult<IQueryable<Photo>> GetListPhotos(int tvId)
        {
            var result = _tvDal.GetPhotos(tvId);
            return new SuccessDataResult<IQueryable<Photo>>(result,Messages.SuccessGet);
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

        public IDataResult<IQueryable<TvAndPhotoDto>> GetListTvWithPhotos()
        {
            var result =  _tvDal.GetTvWithPhotos();
            return new SuccessDataResult<IQueryable<TvAndPhotoDto>>(result,Messages.SuccessGet);
        }
        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<IQueryable<TvAndPhotoDetailDto>> GetListTvDetails()
        {
            var result = _tvDal.GetTvDetails();
            return new SuccessDataResult<IQueryable<TvAndPhotoDetailDto>>(result, Messages.SuccessGet);
        }

        public async Task<IDataResult<TvAndPhotoDetailDto>> GetTvDetailAsync(int tvId)
        {
            var result = await _tvDal.GetTvDetailAsync(x=>x.Id== tvId);
            return new SuccessDataResult<TvAndPhotoDetailDto>(result, Messages.SuccessGet);

        }
        private IResult CheckTvName(Tv entity)
        {
            var tvs = _tvDal.GetAll();
            if(tvs.Any(x => x.ProductName == entity.ProductName))
            {
                return new ErrorResult(Messages.ProductAlreadyExists);
            }
            return new SuccessResult();
        }
        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<IQueryable<TvAndPhotoDetailDto>> GetListTvDetailsByCategoryId(int categoryId)
        {
            var result = _tvDal.GetTvDetails(x => x.BrandId == categoryId);
            return new SuccessDataResult<IQueryable<TvAndPhotoDetailDto>>(result, Messages.SuccessGet);
        }

        //public async Task<IDataResult<List<TvAndPhotoDto>>> GetTvWithPhotos(Expression<Func<TvAndPhotoDto, bool>> filter)
        //{
        //    var result = await _tvDal.GetTvWithPhotos(filter);
        //    return new SuccessDataResult<List<TvAndPhotoDto>>(result, Messages.SuccessGet);
        //}
    }
}
