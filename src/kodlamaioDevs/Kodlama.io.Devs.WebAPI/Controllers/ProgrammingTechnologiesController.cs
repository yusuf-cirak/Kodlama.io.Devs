using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.AddProgrammingTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.DeleteProgammingTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.UpdateProgrammingTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Queries.GetProgammingTechnologyList;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Queries.GetProgrammingTechnologyListDynamic;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class ProgrammingTechnologiesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddProgrammingTechnologyCommandRequest request)
        {
            AddProgrammingTechnologyCommandResponse response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingTechnologyCommandRequest request)
        {
            UpdateProgrammingTechnologyCommandResponse response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteProgrammingTechnologyCommandRequest request)
        {
            DeleteProgrammingTechnologyCommandResponse response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetProgrammingTechnologyListQueryRequest request)
        {
            GetProgrammingTechnologyListQueryResponse response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("dynamic")]
        public async Task<IActionResult> GetListDynamic([FromQuery] PageRequest pageRequest,[FromBody] Dynamic dynamic)
        {
            GetProgrammingTechnologyListDynamicQueryResponse response = await Mediator.Send(new GetProgrammingTechnologyListDynamicQueryRequest{PageRequest = pageRequest,Dynamic = dynamic});
            return Ok(response);
        }
    }
}
