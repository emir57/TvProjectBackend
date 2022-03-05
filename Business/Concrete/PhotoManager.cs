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
using System.Linq;
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
        [SecuredOperation("Admin,Moderator")]
        [ValidationAspect(typeof(PhotoValidator))]
        [CacheRemoveAspect("IPhotoService.Get")]
        [PerformanceAspect(3)]
        public async Task<IResult> AddAsync(Photo entity)
        {
            await _photoDal.AddAsync(entity);
            return new SuccessResult(Messages.SuccessAdd);
        }
        [SecuredOperation("Admin,Moderator")]
        [PerformanceAspect(3)]
        public async Task<IResult> DeleteAsync(Photo entity)
        {
            await _photoDal.DeleteAsync(entity);
            return new SuccessResult(Messages.SuccessDelete);
        }
        [PerformanceAspect(5)]
        [CacheAspect]
        public async Task<IDataResult<Photo>> GetByIdAsync(int photoId)
        {
            var result = await _photoDal.GetAsync(x=>x.Id==photoId);
            return new SuccessDataResult<Photo>(result, Messages.SuccessGet);
        }
        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<IQueryable<Photo>> GetList()
        {
            var result = _photoDal.GetAll();
            return new SuccessDataResult<IQueryable<Photo>>(result, Messages.SuccessGet);
        }
        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<IQueryable<Photo>> GetListByTvId(int tvId)
        {
            var result = _photoDal.GetAll(x=>x.TvId==tvId);
            return new SuccessDataResult<IQueryable<Photo>>(result, Messages.SuccessGet);
        }
        [SecuredOperation("Admin,Moderator")]
        [ValidationAspect(typeof(PhotoValidator))]
        [CacheRemoveAspect("IPhotoService.Get")]
        [PerformanceAspect(3)]
        public async Task<IResult> UpdateAsync(Photo entity)
        {
            await _photoDal.UpdateAsync(entity);
            return new SuccessResult(Messages.SuccessUpdate);
        }
    }
}
