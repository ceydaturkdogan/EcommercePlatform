using ECommercePlatform.Business.Operations.Order;
using ECommercePlatform.Business.Operations.Order.Dtos;
using ECommercePlatform.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommercePlatform.WebApi.Controllers
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order=await _orderService.GetOrder(id);

            if (order is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(order);
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderService.GetOrders();

                return Ok(orders);
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddOrder(AddOrderRequest request)
        {

            var addOrderDto = new AddOrderDto
            {
                OrderName = request.OrderName,
                OrderDate = request.OrderDate,
                TotalAmount = request.TotalAmount,
                ProductId = request.ProductId,

            };

            var result = await _orderService.AddOrder(addOrderDto);
            if (!result.IsSucceed)
            {
                return BadRequest(result.Message);
            }
            else
            {
                return Ok();
            }
        }

        [HttpPatch("{id}/totalamount")]

        public async Task<IActionResult>  AdjustTotalAmount(int id,decimal changeTo)
        {
            var result=await _orderService.AdjustTotalAmount(id, changeTo);

            if (!result.IsSucceed)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result= await _orderService.DeleteOrder(id);

            if (!result.IsSucceed)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }

        }

    }
}
