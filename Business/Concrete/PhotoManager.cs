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
    public class PhotoManager:IPhotoService
    {
        private readonly IPhotoDal _photoDal;

        public PhotoManager(IPhotoDal photoDal)
        {
            _photoDal = photoDal;
        }
        [ValidationAspect(typeof(PhotoValidator))]
        [CacheRemoveAspect("Get")]
        [PerformanceAspect(3)]
        public async Task<IResult> Add(Photo entity)
        {
            await _photoDal.Add(entity);
            return new SuccessResult(Messages.SuccessAdd);
        }
        [PerformanceAspect(3)]
        public async Task<IResult> Delete(Photo entity)
        {
            await _photoDal.Delete(entity);
            return new SuccessResult(Messages.SuccessDelete);
        }
        [PerformanceAspect(5)]
        [CacheAspect]
        public async Task<IDataResult<Photo>> Get(Expression<Func<Photo, bool>> filter)
        {
            var result = await _photoDal.Get(filter);
            return new SuccessDataResult<Photo>(result, Messages.SuccessGet);
        }
        [PerformanceAspect(5)]
        [CacheAspect]
        public async Task<IDataResult<List<Photo>>> GetAll(Expression<Func<Photo, bool>> filter = null)
        {
            var result = filter == null ?
                await _photoDal.GetAll() :
                await _photoDal.GetAll(filter);
            return new SuccessDataResult<List<Photo>>(result, Messages.SuccessGet);

        }
        [ValidationAspect(typeof(PhotoValidator))]
        [CacheRemoveAspect("Get")]
        [PerformanceAspect(3)]
        public async Task<IResult> Update(Photo entity)
        {
            await _photoDal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdate);
        }
    }
}
