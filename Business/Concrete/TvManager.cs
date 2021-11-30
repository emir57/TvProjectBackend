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
    public class TvManager:ITvService
    {
        private readonly ITvDal _tvDal;

        public TvManager(ITvDal tvDal)
        {
            _tvDal = tvDal;
        }

        public async Task<IResult> Add(Tv entity)
        {
            await _tvDal.Add(entity);
            return new SuccessResult(Messages.SuccessAdd);
        }

        public async Task<IResult> Delete(Tv entity)
        {
            await _tvDal.Delete(entity);
            return new SuccessResult(Messages.SuccessDelete);
        }

        public async Task<IDataResult<Tv>> Get(Expression<Func<Tv, bool>> filter)
        {
            var result = await _tvDal.Get(filter);
            return new SuccessDataResult<Tv>(result, Messages.SuccessGet);
        }

        public async Task<IDataResult<List<Tv>>> GetAll(Expression<Func<Tv, bool>> filter = null)
        {
            return filter == null ?
                new SuccessDataResult<List<Tv>>(await _tvDal.GetAll(), Messages.SuccessGet) :
                new SuccessDataResult<List<Tv>>(await _tvDal.GetAll(filter), Messages.SuccessGet);

        }

        public async Task<IDataResult<List<Tv>>> GetByBrand(int brandId)
        {
            var result = await _tvDal.GetAll(t => t.BrandId == brandId);
            return new SuccessDataResult<List<Tv>>(result, Messages.SuccessGet);
            
        }

        public async Task<IResult> Update(Tv entity)
        {
            await _tvDal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdate);
        }
    }
}
