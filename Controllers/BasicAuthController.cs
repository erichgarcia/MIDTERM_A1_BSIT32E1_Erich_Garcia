using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MIDTERM_A1_BASICAUTH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasicAuthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("You are in");
        }
    }   
}
