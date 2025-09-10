using Microsoft.AspNetCore.Mvc;
using MIT.BL;

namespace MIT.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private IOrderService _orderService;
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<IActionResult> AddNewOrder(AddOrderDto request)
    {
        var result = await _orderService.AddNewOrderAsync(request);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetOrderById(int id)
    {
        var result = await _orderService.GetOrderByIdAsync(id);
        return result.IsSuccess ? Ok(result) : NotFound(result);
    }

    [HttpPost("UpdateOrderStatus/{id:int}")]
    public async Task<IActionResult> UpdateStatus(int id)
    {
        var result = await _orderService.UpdateOrderStatusAsync(id, OrderStatus.Delivered);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}
