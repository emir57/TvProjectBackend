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
    public class TvPhotoManager:ITvPhotoService
    {
        private readonly ITvPhotoDal _tvPhotoDal;

        public TvPhotoManager(ITvPhotoDal tvPhotoDal)
        {
            _tvPhotoDal = tvPhotoDal;
        }

        public async Task<IResult> Add(TvPhoto entity)
        {
            await _tvPhotoDal.Add(entity);
            return new SuccessResult(Messages.SuccessAdd);
        }

        public async Task<IResult> Delete(TvPhoto entity)
        {
            await _tvPhotoDal.Delete(entity);
            return new SuccessResult(Messages.SuccessDelete);
        }

        public async Task<IDataResult<TvPhoto>> Get(Expression<Func<TvPhoto, bool>> filter)
        {
            var result = await _tvPhotoDal.Get(filter);
            return new SuccessDataResult<TvPhoto>(result, Messages.SuccessGet);
        }

        public async Task<IDataResult<List<TvPhoto>>> GetAll(Expression<Func<TvPhoto, bool>> filter = null)
        {
            var result = filter == null ?
                await _tvPhotoDal.GetAll() :
                await _tvPhotoDal.GetAll(filter);
            return new SuccessDataResult<List<TvPhoto>>(result, Messages.SuccessGet);
        }

        public async Task<IResult> Update(TvPhoto entity)
        {
            await _tvPhotoDal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdate);
        }
    }
}
