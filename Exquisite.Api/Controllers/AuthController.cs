using Microsoft.AspNetCore.Mvc;

namespace Exquisite.Api.Controllers
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
