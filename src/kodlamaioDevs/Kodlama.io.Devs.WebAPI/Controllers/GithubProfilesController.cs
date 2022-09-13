using Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.AddGithubProfile;
using Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.DeleteGithubProfile;
using Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.UpdateGithubProfile;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubProfilesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddGithubProfileCommandRequest request)
        {
            AddGithubProfileCommandResponse response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteGithubProfileCommandRequest request)
        {
            DeleteGithubProfileCommandResponse response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateGithubProfileCommandRequest request)
        {
            UpdateGithubProfileCommandResponse response = await Mediator.Send(request);
            return Ok(response);
        }
    }
}
