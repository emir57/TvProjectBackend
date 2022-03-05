using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        Task<IResult> AddAsync(Order entity);
        Task<IResult> UpdateAsync(Order entity);
        Task<IResult> DeleteAsync(Order entity);
        Task<IDataResult<Order>> GetByIdAsync(int orderId);
        IDataResult<IQueryable<Order>> GetList();
        IDataResult<IQueryable<OrderDto>> GetOrdersByUserId(int userId);
        IDataResult<IQueryable<OrderDto>> GetListOrdersDto();

    }
}
