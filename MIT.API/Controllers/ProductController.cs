using Microsoft.AspNetCore.Mvc;
using MIT.BL;

namespace MIT.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

}
