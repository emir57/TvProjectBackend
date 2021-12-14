﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        [SecuredOperation("User,Admin")]
        //[ValidationAspect(typeof())]
        [CacheRemoveAspect("IOrderService.Get")]
        [PerformanceAspect(5)]
        public async Task<IResult> Add(Order entity)
        {
            await _orderDal.Add(entity);
            return new SuccessResult(Messages.SuccessAdd);
        }
        [SecuredOperation("User,Admin")]
        [CacheRemoveAspect("IOrderService.Get")]
        [PerformanceAspect(5)]
        public async Task<IResult> Delete(Order entity)
        {
            await _orderDal.Delete(entity);
            return new SuccessResult(Messages.SuccessDelete);
        }
        [SecuredOperation("User,Admin")]
        [CacheAspect]
        [PerformanceAspect(8)]
        public async Task<IDataResult<Order>> Get(Expression<Func<Order, bool>> filter)
        {
            var result = await _orderDal.Get(filter);
            return new SuccessDataResult<Order>(result, Messages.SuccessGet);
        }
        [SecuredOperation("Admin")]
        [CacheAspect]
        [PerformanceAspect(8)]
        public async Task<IDataResult<List<Order>>> GetAll(Expression<Func<Order, bool>> filter = null)
        {
            var result = filter == null ?
                await _orderDal.GetAll() :
                await _orderDal.GetAll(filter);
            return new SuccessDataResult<List<Order>>(result, Messages.SuccessGet);
        }
        [SecuredOperation("User,Admin")]
        [CacheAspect]
        [PerformanceAspect(8)]
        public async Task<IDataResult<List<OrderDto>>> GetOrdersByUserId(int userId)
        {
            var result = await _orderDal.GetOrdersByUserId(userId);
            return new SuccessDataResult<List<OrderDto>>(result, Messages.SuccessGet);
        }
        [SecuredOperation("User,Admin")]
        //[ValidationAspect(typeof())]
        [CacheRemoveAspect("IOrderService.Get")]
        [PerformanceAspect(5)]
        public async Task<IResult> Update(Order entity)
        {
            await _orderDal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdate);
        }
    }
}
