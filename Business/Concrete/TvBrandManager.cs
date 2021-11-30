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
    public class TvBrandManager:ITvBrandService
    {
        private readonly ITvBrandDal _tvBrandDal;

        public TvBrandManager(ITvBrandDal tvBrandDal)
        {
            _tvBrandDal = tvBrandDal;
        }

        public async Task<IResult> Add(TvBrand entity)
        {
            await _tvBrandDal.Add(entity);
            return new SuccessResult(Messages.SuccessAdd);
        }

        public async Task<IResult> Delete(TvBrand entity)
        {
            await _tvBrandDal.Delete(entity);
            return new SuccessResult(Messages.SuccessDelete);
        }

        public async Task<IDataResult<TvBrand>> Get(Expression<Func<TvBrand, bool>> filter)
        {
            var result = await _tvBrandDal.Get(filter);
            return new SuccessDataResult<TvBrand>(result, Messages.SuccessGet);
        }

        public async Task<IDataResult<List<TvBrand>>> GetAll(Expression<Func<TvBrand, bool>> filter = null)
        {
            var result = filter == null ?
                await _tvBrandDal.GetAll() :
                await _tvBrandDal.GetAll(filter);
            return new SuccessDataResult<List<TvBrand>>(result, Messages.SuccessGet);
        }

        public async Task<IResult> Update(TvBrand entity)
        {
            await _tvBrandDal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdate);
        }
    }
}
