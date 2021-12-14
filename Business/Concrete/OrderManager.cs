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
            throw new NotImplementedException();
        }

        public async Task<IDataResult<List<Order>>> GetAll(Expression<Func<Order, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderDto>> GetOrdersByUserId(int userId)
        {
            var res
        }

        public async Task<IResult> Update(Order entity)
        {
            await _orderDal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdate);
        }
    }
}
