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
    public class CityManager : ICityService
    {
        private readonly ICityDal _citydal;

        public CityManager(ICityDal citydal)
        {
            _citydal = citydal;
        }
        [SecuredOperation("Admin,Moderator")]
        [ValidationAspect(typeof(CityValidator))]
        [CacheRemoveAspect("ICityService.Get")]
        [PerformanceAspect(3)]
        public async Task<IResult> Add(City entity)
        {
            await _citydal.Add(entity);
            return new SuccessResult(Messages.SuccessAdd);
        }
        [SecuredOperation("Admin,Moderator")]
        [CacheRemoveAspect("ICityService.Get")]
        [PerformanceAspect(3)]
        public async Task<IResult> Delete(City entity)
        {
            await _citydal.Delete(entity);
            return new SuccessResult(Messages.SuccessDelete);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public async Task<IDataResult<City>> GetById(int cityId)
        {
            var result = await _citydal.Get(x=>x.Id==cityId);
            return new SuccessDataResult<City>(result, Messages.SuccessGet);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public async Task<IDataResult<List<City>>> GetAll()
        {
            var result = await _citydal.GetAll();
            return new SuccessDataResult<List<City>>(result, Messages.SuccessGet);
        }
        [SecuredOperation("Admin,Moderator")]
        [ValidationAspect(typeof(CityValidator))]
        [CacheRemoveAspect("ICityService.Get")]
        [PerformanceAspect(3)]
        public async Task<IResult> Update(City entity)
        {
            await _citydal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdate);
        }
    }
}
