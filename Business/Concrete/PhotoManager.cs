using Business.Abstract;
using Business.Constants;
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

        public async Task<IResult> Add(Photo entity)
        {
            await _photoDal.Add(entity);
            return new SuccessResult(Messages.SuccessAdd);
        }

        public async Task<IResult> Delete(Photo entity)
        {
            await _photoDal.Delete(entity);
            return new SuccessResult(Messages.SuccessDelete);
        }

        public async Task<IDataResult<Photo>> Get(Expression<Func<Photo, bool>> filter)
        {
            var result = await _photoDal.Get(filter);
            return new SuccessDataResult<Photo>(result, Messages.SuccessGet);
        }

        public async Task<IDataResult<List<Photo>>> GetAll(Expression<Func<Photo, bool>> filter = null)
        {
            return filter == null ?
                new SuccessDataResult<List<Photo>>(await _photoDal.GetAll(), Messages.SuccessGet) :
                new SuccessDataResult<List<Photo>>(await _photoDal.GetAll(filter), Messages.SuccessGet);

        }

        public async Task<IResult> Update(Photo entity)
        {
            await _photoDal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdate);
        }
    }
}
