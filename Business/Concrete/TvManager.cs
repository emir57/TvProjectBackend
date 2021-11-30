using Business.Abstract;
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
    public class TvManager:ITvService
    {
        private readonly ITvDal _tvDal;

        public TvManager(ITvDal tvDal)
        {
            _tvDal = tvDal;
        }
        [ValidationAspect(typeof(TvValidator))]
        [CacheRemoveAspect("Get")]
        [PerformanceAspect(3)]
        public async Task<IResult> Add(Tv entity)
        {
            await _tvDal.Add(entity);
            return new SuccessResult(Messages.SuccessAdd);
        }
        [CacheRemoveAspect("Get")]
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
            return new SuccessDataResult<List<Tv>>(result, Messages.SuccessGet);
        }

        public async Task<IDataResult<List<Tv>>> GetByBrand(int brandId)
        {
            var result = await _tvDal.GetAll(t => t.BrandId == brandId);
            return new SuccessDataResult<List<Tv>>(result, Messages.SuccessGet);
            
        }
        [ValidationAspect(typeof(TvValidator))]
        [CacheRemoveAspect("Get")]
        [PerformanceAspect(3)]
        public async Task<IResult> Update(Tv entity)
        {
            await _tvDal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdate);
        }
    }
}
