using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("Login")]
        public ActionResult Login()
        {
            return Ok();
        }

        [HttpPost("CheckToken")]
        public ActionResult CheckToken()
        {
            return Ok();
        }
    }
}
