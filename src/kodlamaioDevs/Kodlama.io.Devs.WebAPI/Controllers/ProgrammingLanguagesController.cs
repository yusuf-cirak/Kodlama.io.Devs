using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.AddProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetProgrammingLanguageById;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetProgrammingLanguageList;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public sealed class ProgrammingLanguagesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddProgrammingLanguageCommandRequest request)
        {
            AddProgrammingLanguageCommandResponse response = await Mediator.Send(request);
            return Created("", response);
        }
        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageCommandRequest request)
        {
            UpdateProgrammingLanguageCommandResponse response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteProgrammingLanguageCommandRequest request)
        {
            DeleteProgrammingLanguageCommandResponse response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetProgrammingLanguageListQueryRequest request)
        {
            GetProgrammingLanguageListQueryResponse response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetProgrammingLanguageByIdQueryRequest request)
        {
            GetProgrammingLanguageByIdQueryResponse response = await Mediator.Send(request);
            return Ok(response);
        }
}
