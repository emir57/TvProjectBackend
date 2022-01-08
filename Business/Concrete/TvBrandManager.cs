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
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TvBrandManager:ITvBrandService
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
        public async Task<IResult> Add(TvBrand entity)
        {
            await _tvBrandDal.Add(entity);
            return new SuccessResult(Messages.SuccessAdd);
        }
        [SecuredOperation("Admin,Moderator")]
        [CacheRemoveAspect("ITvBrandService.Get")]
        [PerformanceAspect(3)]
        public async Task<IResult> Delete(TvBrand entity)
        {
            await _tvBrandDal.Delete(entity);
            return new SuccessResult(Messages.SuccessDelete);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public async Task<IDataResult<TvBrand>> GetById(int brandId)
        {
            var result = await _tvBrandDal.Get(x=>x.Id==brandId);
            return new SuccessDataResult<TvBrand>(result, Messages.SuccessGet);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public async Task<IDataResult<List<TvBrand>>> GetList()
        {
            var result = await _tvBrandDal.GetAll();
            return new SuccessDataResult<List<TvBrand>>(result, Messages.SuccessGet);
        }
        [SecuredOperation("Admin,Moderator")]
        [ValidationAspect(typeof(TvBrandValidator))]
        [CacheRemoveAspect("ITvBrandService.Get")]
        [PerformanceAspect(3)]
        public async Task<IResult> Update(TvBrand entity)
        {
            await _tvBrandDal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdate);
        }
    }
}
