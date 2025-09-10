using Microsoft.AspNetCore.Mvc;
using MIT.BL;

namespace MIT.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{

    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _customerService.GetAllAsync();
        return result.IsSuccess ? Ok(result) : StatusCode(500, result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _customerService.GetByIdAsync(id);
        return result.IsSuccess ? Ok(result) : NotFound(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(AddCustomerDto request)
    {
        var result = await _customerService.AddAsync(request);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}
