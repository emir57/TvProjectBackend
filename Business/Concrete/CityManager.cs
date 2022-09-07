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
using System.Collections.Generic;
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
        public async Task<IResult> AddAsync(City entity)
        {
            await _citydal.AddAsync(entity);
            return new SuccessResult(Messages.SuccessAdd);
        }
        [SecuredOperation("Admin,Moderator")]
        [CacheRemoveAspect("ICityService.Get")]
        [PerformanceAspect(3)]
        public async Task<IResult> DeleteAsync(City entity)
        {
            await _citydal.DeleteAsync(entity);
            return new SuccessResult(Messages.SuccessDelete);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public async Task<IDataResult<City>> GetByIdAsync(int cityId)
        {
            City city = await _citydal.GetAsync(x => x.Id == cityId);
            if (city == null)
                return new ErrorDataResult<City>(Messages.CityIsNotFound);

            return new SuccessDataResult<City>(city, Messages.SuccessGet);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public async Task<IDataResult<List<City>>> GetListAsync()
        {
            List<City> cities = await _citydal.GetAllAsync();
            return new SuccessDataResult<List<City>>(cities, Messages.SuccessGet);
        }
        [SecuredOperation("Admin,Moderator")]
        [ValidationAspect(typeof(CityValidator))]
        [CacheRemoveAspect("ICityService.Get")]
        [PerformanceAspect(3)]
        public async Task<IResult> UpdateAsync(City entity)
        {
            await _citydal.UpdateAsync(entity);
            return new SuccessResult(Messages.SuccessUpdate);
        }
    }
}
