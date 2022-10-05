using Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.Add;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.Delete;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Queries.GetList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetUserOperationClaimsListQueryRequest request)
        {
            var response = await Mediator.Send(request);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddUserOperationClaimCommandRequest request)
        {
            var response = await Mediator.Send(request);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Add([FromBody] DeleteUserOperationClaimCommandRequest request)
        {
            var response = await Mediator.Send(request);

            return Ok(response);
        }
    }
}
