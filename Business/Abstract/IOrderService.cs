using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        Task<IResult> Add(Order entity);
        Task<IResult> Update(Order entity);
        Task<IResult> Delete(Order entity);
        Task<IDataResult<Order>> Get(Expression<Func<Order, bool>> filter);
        Task<IDataResult<List<Order>>> GetAll(Expression<Func<Order, bool>> filter = null);
        Task<List<OrderDto>> GetOrdersByUserId(int userId);

    }
}
