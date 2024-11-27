using Microsoft.AspNetCore.Mvc;

namespace MyBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet("GetProducts")]
    public IActionResult GetProducts()
    {
        var products = new List<string> { "Product1", "Product2", "Product3" };
        return Ok(products);
    }
}