using Core.Security.Dtos;
using Kodlama.io.Devs.Application.Features.Auths.Commands.Login;
using Kodlama.io.Devs.Application.Features.Auths.Commands.RegisterUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class AuthController : BaseController
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            var request = new RegisterCommandRequest(userForRegisterDto:userForRegisterDto,ipAddress: GetIpAddress()!);

             var response = await Mediator.Send(request);

            SetRefreshTokenToCookie(response.RefreshToken);

            return Ok(response.AccessToken);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginCommandRequest request)
        {
            LoginCommandResponse response = await Mediator.Send(request);
            return Ok(response);
        }
    }
}
