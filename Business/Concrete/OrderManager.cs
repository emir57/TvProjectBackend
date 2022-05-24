using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.Validators.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;
        private readonly ITvService _tvService;

        public OrderManager(IOrderDal orderDal, ITvService tvService)
        {
            _orderDal = orderDal;
            _tvService = tvService;
        }
        [SecuredOperation("User,Admin")]
        [ValidationAspect(typeof(OrderValidator))]
        [CacheRemoveAspect("IOrderService.Get")]
        [PerformanceAspect(5)]
        public async Task<IResult> AddAsync(Order entity)
        {
            Thread.Sleep(4000);
            IResult result = BusinessRules.Run(
                await CheckTvAsync(entity.TvId),
                await CheckProductStockAsync(entity.TvId));
            if (result != null)
            {
                return result;
            }
            entity.ShippedDate = DateTime.Now;
            await _orderDal.AddAsync(entity);
            await UpdateTvAsync(entity.TvId,StockStatus.Decrease);
            return new SuccessResult(Messages.SuccessOrder);
        }

        private async Task UpdateTvAsync(int tvId,StockStatus stockStatus)
        {
            var tv = (await _tvService.GetByIdAsync(tvId)).Data;
            switch (stockStatus)    
            {
                case StockStatus.Increase:
                    tv.Stock += 1;
                    break;
                case StockStatus.Decrease:
                    tv.Stock -= 1;
                    break;
            }
            await _tvService.UpdateAsync(tv);
        }

        private enum StockStatus
        {
            Increase,
            Decrease
        }

        private async Task<IResult> CheckTvAsync(int tvId)
        {
            var tv = await _tvService.GetByIdAsync(tvId);
            if(tv.Data == null)
            {
                return new ErrorResult(Messages.TvNotFound);
            }
            return new SuccessResult();
        }

        private async Task<IResult> CheckProductStockAsync(int tvId)
        {
            var tv = await _tvService.GetByIdAsync(tvId);
            if (tv.Data.Stock < 1)
            {
                return new ErrorResult(Messages.TvStock0);
            }
            return new SuccessResult();
        }

        [SecuredOperation("User,Admin")]
        [CacheRemoveAspect("IOrderService.Get")]
        [PerformanceAspect(5)]
        public async Task<IResult> DeleteAsync(Order entity)
        {
            await UpdateTvAsync(entity.TvId, StockStatus.Increase);
            await _orderDal.DeleteAsync(entity);
            return new SuccessResult(Messages.SuccessDelete);
        }
        [SecuredOperation("User,Admin")]
        [CacheAspect]
        [PerformanceAspect(8)]
        public async Task<IDataResult<Order>> GetByIdAsync(int orderId)
        {
            Order order = await _orderDal.GetAsync(x => x.Id == orderId);
            return new SuccessDataResult<Order>(order, Messages.SuccessGet);
        }
        [SecuredOperation("Admin")]
        [CacheAspect]
        [PerformanceAspect(8)]
        public async Task<IDataResult<List<Order>>> GetListAsync()
        {
            List<Order> orders = await _orderDal.GetAllAsync();
            return new SuccessDataResult<List<Order>>(orders, Messages.SuccessGet);
        }
        [SecuredOperation("Admin")]
        [CacheAspect]
        [PerformanceAspect(8)]
        public async Task<IDataResult<List<OrderDto>>> GetListOrdersDtoAsync()
        {
            List<OrderDto> orderDtos = await _orderDal.GetAllOrdersDtoAsync();
            return new SuccessDataResult<List<OrderDto>>(orderDtos, Messages.SuccessGet);
        }

        [SecuredOperation("User,Admin")]
        [CacheAspect]
        [PerformanceAspect(8)]
        public async Task<IDataResult<List<OrderDto>>> GetOrdersByUserIdAsync(int userId)
        {
            List<OrderDto> orderDtos = await _orderDal.GetOrdersByUserIdAsync(userId);
            return new SuccessDataResult<List<OrderDto>>(orderDtos, Messages.SuccessGet);
        }
        [SecuredOperation("User,Admin")]
        //[ValidationAspect(typeof())]
        [CacheRemoveAspect("IOrderService.Get")]
        [PerformanceAspect(5)]
        public async Task<IResult> UpdateAsync(Order entity)
        {
            await _orderDal.UpdateAsync(entity);
            return new SuccessResult(Messages.SuccessUpdate);
        }
    }
}
