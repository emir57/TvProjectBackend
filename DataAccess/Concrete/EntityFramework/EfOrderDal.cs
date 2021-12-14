using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, TvProjectContext>, IOrderDal
    {
        public Task<OrderDto> GetOrderByUserId(int userId)
        {
            //var result = 
            return;
        }
    }
}
