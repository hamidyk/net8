using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{
    [HttpGet]
    [Authorize]
    [HttpGet("GetProfile")]
    public IActionResult GetProfile()
    {
        return Ok(new { Name = "John Doe", Email = "john.doe@example.com" });
    }
}