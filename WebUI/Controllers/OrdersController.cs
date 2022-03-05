using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        [Route("getall")]
        public IActionResult GetOrders()
        {
            var result = _orderService.GetListOrdersDtoAsync();
            if (!result.IsSuccess)
            {
                return Ok(result);
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("getbyid")]
        public IActionResult GetOrders(int id)
        {
            var result = _orderService.GetOrdersByUserIdAsync(id);
            if (!result.IsSuccess)
            {
                return Ok(result);
            }
            return Ok(result);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order.Data == null)
            {
                return Ok(new ErrorResult(Messages.OrderIsNotFound));
            }
            var result = await _orderService.DeleteAsync(order.Data);
            if (!result.IsSuccess)
            {
                return Ok(result);
            }
            return Ok(result);
        }
    }
}
