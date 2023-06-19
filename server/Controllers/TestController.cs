using Microsoft.AspNetCore.Mvc;

namespace server.Controllers.TestController;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet("test")]
    public IActionResult Test()
    {
        return Ok("Test");
    }
}
