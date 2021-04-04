using Exquisite.BusinessLogic.UserManagement.Commands;
using Exquisite.BusinessLogic.UserManagement.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Exquisite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public ActionResult Create([FromBody] CreateUserCommand command)
        {
            _mediator.Send(command);
            return Ok();
        }

        [HttpGet("All")]
        public async Task<ActionResult> All()
        {
            var response = await _mediator.Send(new AllUserQuery());
            return Ok(response);
        }
    }
}
