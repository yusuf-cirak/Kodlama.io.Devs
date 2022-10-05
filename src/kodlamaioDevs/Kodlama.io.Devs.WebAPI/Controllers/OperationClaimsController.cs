using Kodlama.io.Devs.Application.Features.OperationClaims.Commands.Create;
using Kodlama.io.Devs.Application.Features.OperationClaims.Commands.Delete;
using Kodlama.io.Devs.Application.Features.OperationClaims.Commands.Update;
using Kodlama.io.Devs.Application.Features.OperationClaims.Queries.GetList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class OperationClaimsController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetOperationClaimListQueryRequest request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOperationClaimCommandRequest request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteOperationClaimCommandRequest request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOperationClaimCommandRequest request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }
    }
}
