using Business.Abstract;
using Business.Constants;
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

        public async Task<IResult> Add(Order entity)
        {
            await _orderDal.Add(entity);
            return new SuccessResult(Messages.SuccessAdd);
        }

        public async Task<IResult> Delete(Order entity)
        {
            await _orderDal.Delete(entity);
            return new SuccessResult(Messages.SuccessDelete);
        }

        public async Task<IDataResult<Order>> Get(Expression<Func<Order, bool>> filter)
        {
            var result = await _orderDal.Get(filter);
            return new SuccessDataResult<Order>(result, Messages.SuccessGet);
        }

        public async Task<IDataResult<List<Order>>> GetAll(Expression<Func<Order, bool>> filter = null)
        {
            var result = filter == null ?
                await _orderDal.GetAll() :
                await _orderDal.GetAll(filter);
            return new SuccessDataResult<List<Order>>(result, Messages.SuccessGet);
        }

        public async Task<IDataResult<List<OrderDto>>> GetOrdersByUserId(int userId)
        {
            var result = await _orderDal.GetOrdersByUserId(userId);
            return new SuccessDataResult<List<OrderDto>>(result, Messages.SuccessGet);
        }

        public async Task<IResult> Update(Order entity)
        {
            await _orderDal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdate);
        }
    }
}
