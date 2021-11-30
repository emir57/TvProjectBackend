﻿using Business.Abstract;
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
    public class CityManager : ICityService
    {
        private readonly ICityDal _citydal;

        public CityManager(ICityDal citydal)
        {
            _citydal = citydal;
        }

        public async Task<IResult> Add(City entity)
        {
            await _citydal.Add(entity);
            return new SuccessResult(Messages.SuccessAdd);
        }

        public async Task<IResult> Delete(City entity)
        {
            await _citydal.Delete(entity);
            return new SuccessResult(Messages.SuccessDelete);
        }

        public async Task<IDataResult<City>> Get(Expression<Func<City, bool>> filter)
        {
            var result = await _citydal.Get(filter);
            return new SuccessDataResult<City>(result, Messages.SuccessGet);
        }

        public async Task<IDataResult<List<City>>> GetAll(Expression<Func<City, bool>> filter = null)
        {
            var result = filter == null ?
                await _citydal.GetAll() :
                await _citydal.GetAll(filter);
            return new SuccessDataResult<List<City>>(result, Messages.SuccessGet);
        }

        public async Task<IResult> Update(City entity)
        {
            await _citydal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdate);
        }
    }
}