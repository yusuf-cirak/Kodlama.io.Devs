using Kodlama.io.Devs.Application.Features.Users.Commands.LoginUser;
using Kodlama.io.Devs.Application.Features.Users.Commands.RegisterUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class AuthController : BaseController
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommandRequest request)
        {
            RegisterUserCommandResponse response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommandRequest request)
        {
            LoginUserCommandResponse response = await Mediator.Send(request);
            return Ok(response);
        }
    }
}
