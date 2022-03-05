using Business.Abstract;
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
using System.Linq;
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
        public async Task<IResult> AddAsync(Order entity)
        {
            await _orderDal.AddAsync(entity);
            return new SuccessResult(Messages.SuccessAdd);
        }
        [SecuredOperation("User,Admin")]
        [CacheRemoveAspect("IOrderService.Get")]
        [PerformanceAspect(5)]
        public async Task<IResult> DeleteAsync(Order entity)
        {
            await _orderDal.DeleteAsync(entity);
            return new SuccessResult(Messages.SuccessDelete);
        }
        [SecuredOperation("User,Admin")]
        [CacheAspect]
        [PerformanceAspect(8)]
        public async Task<IDataResult<Order>> GetByIdAsync(int orderId)
        {
            var result = await _orderDal.GetAsync(x=>x.Id==orderId);
            return new SuccessDataResult<Order>(result, Messages.SuccessGet);
        }
        [SecuredOperation("Admin")]
        [CacheAspect]
        [PerformanceAspect(8)]
        public IDataResult<IQueryable<Order>> GetList()
        {
            var result = _orderDal.GetAll();
            return new SuccessDataResult<IQueryable<Order>>(result, Messages.SuccessGet);
        }

        public IDataResult<IQueryable<OrderDto>> GetListOrdersDto()
        {
            var result = _orderDal.GetAllOrdersDto();
            return new SuccessDataResult<IQueryable<OrderDto>>(result, Messages.SuccessGet);
        }

        [SecuredOperation("User,Admin")]
        [CacheAspect]
        [PerformanceAspect(8)]
        public IDataResult<IQueryable<OrderDto>> GetOrdersByUserId(int userId)
        {
            var result = _orderDal.GetOrdersByUserId(userId);
            return new SuccessDataResult<IQueryable<OrderDto>>(result, Messages.SuccessGet);
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
