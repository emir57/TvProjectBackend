using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Abstract
{
    public interface IOrderDal:IEntityRepository<Order>
    {
        Task<List<OrderDto>> GetOrdersByUserIdAsync(int userId);
        Task<List<OrderDto>> GetAllOrdersDtoAsync(Expression<Func<OrderDto,bool>> filter=null);
    }
}
