using Application.Features.Auth.Commands.Login;
using Domain.Shared.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AYEP.PersonelTayinTalepWebApi.Controllers.Auth
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginPersonelCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.Success)
                return Unauthorized(result.Message);
            return Ok(result);
        }

        // Şifre değiştirme, sıfırlama gibi işlemler için buraya ekleyebilirsin.
    }
}
