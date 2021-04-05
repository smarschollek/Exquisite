using System.Threading.Tasks;
using Exquisite.BusinessLogic.RecipeManagement.Commands;
using Exquisite.BusinessLogic.RecipeManagement.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Exquisite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RecipeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] CreateRecipeCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        
        [HttpPost("SetLabels")]
        public async Task<ActionResult> SetLabels([FromBody] SetLabelsCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        
        [HttpPost("Delete")]
        public async Task<ActionResult> Delete([FromBody] DeleteRecipeCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        
        [HttpGet("All")]
        public async Task<ActionResult> All()
        {
            var response =await _mediator.Send(new AllRecipesQuery());
            return Ok(response);
        }
    }
}