using Application.Features.Auth.Commands.Login;
using Application.Features.Personeller.Command.Delete;
using Application.Features.Personeller.Command.Update;
using Application.Features.Personeller.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AYEP.PersonelTayinTalepWebApi.Controllers.Personeller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonelController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// Tüm personelleri getirir.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IResult>> GetAll()
        {
            var result = await _mediator.Send(new GetAllPersonelQuery());
            return Ok(result);
        }

        /// <summary>
        /// Personel Id ile personeli getirir.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<IResult>> GetById(int id)
        {
            var result = await _mediator.Send(new GetPersonelByIdQuery { Id = id });           
            return Ok(result);
        }

        /// <summary>
        /// Personel oluşturur.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<IResult>> Create([FromBody] CreatePersonelCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        /// <summary>
        /// Personel günceller.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<IResult>> Update(int id, [FromBody] UpdatePersonelCommand command)
        {
            if (id != command.id)
                return BadRequest("Id uyuşmuyor.");
            var result = await _mediator.Send(command);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        /// <summary>
        /// Personel siler.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult<IResult>> Delete(int id)
        {
            var result = await _mediator.Send(new DeletePersonelCommand { Id = id });
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        /// <summary>
        /// Personel login (JWT üretir, Auth kullanır).
        /// </summary>
        [HttpPost("login")]
        public async Task<ActionResult<IResult>> Login([FromBody] LoginPersonelCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.Success)
                return Unauthorized(result.Message);
            return Ok(result);
        }
    }
}
