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
            await _orderDal.Add(entity);
            return new SuccessResult(Messages.SuccessAdd);
        }
        [SecuredOperation("User,Admin")]
        [CacheRemoveAspect("IOrderService.Get")]
        [PerformanceAspect(5)]
        public async Task<IResult> DeleteAsync(Order entity)
        {
            await _orderDal.Delete(entity);
            return new SuccessResult(Messages.SuccessDelete);
        }
        [SecuredOperation("User,Admin")]
        [CacheAspect]
        [PerformanceAspect(8)]
        public async Task<IDataResult<Order>> GetByIdAsync(int orderId)
        {
            var result = await _orderDal.Get(x=>x.Id==orderId);
            return new SuccessDataResult<Order>(result, Messages.SuccessGet);
        }
        [SecuredOperation("Admin")]
        [CacheAspect]
        [PerformanceAspect(8)]
        public async Task<IDataResult<List<Order>>> GetListAsync()
        {
            var result = await _orderDal.GetAll();
            return new SuccessDataResult<List<Order>>(result, Messages.SuccessGet);
        }

        public async Task<IDataResult<List<OrderDto>>> GetListOrdersDtoAsync()
        {
            var result = await _orderDal.GetAllOrdersDto();
            return new SuccessDataResult<List<OrderDto>>(result, Messages.SuccessGet);
        }

        [SecuredOperation("User,Admin")]
        [CacheAspect]
        [PerformanceAspect(8)]
        public async Task<IDataResult<List<OrderDto>>> GetOrdersByUserIdAsync(int userId)
        {
            var result = await _orderDal.GetOrdersByUserId(userId);
            return new SuccessDataResult<List<OrderDto>>(result, Messages.SuccessGet);
        }
        [SecuredOperation("User,Admin")]
        //[ValidationAspect(typeof())]
        [CacheRemoveAspect("IOrderService.Get")]
        [PerformanceAspect(5)]
        public async Task<IResult> UpdateAsync(Order entity)
        {
            await _orderDal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdate);
        }
    }
}
