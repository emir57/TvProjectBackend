using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
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
        [HttpPost]
        public async Task<IActionResult> AddOrder(Order order)
        {
            IResult result = await _orderService.AddAsync(order);
            if (result.IsSuccess == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            IDataResult<List<OrderDto>> result = await _orderService.GetListOrdersDtoAsync();
            if (result.IsSuccess == false)
            {
                return Ok(result);
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            IDataResult<List<OrderDto>> result = await _orderService.GetOrdersByUserIdAsync(id);
            if (result.IsSuccess == false)
            {
                return Ok(result);
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            IDataResult<Order> order = await _orderService.GetByIdAsync(id);
            if (order.Data == null)
            {
                return Ok(new ErrorResult(Messages.OrderIsNotFound));
            }
            IResult result = await _orderService.DeleteAsync(order.Data);
            if (result.IsSuccess == false)
            {
                return Ok(result);
            }
            return Ok(result);
        }
    }
}
