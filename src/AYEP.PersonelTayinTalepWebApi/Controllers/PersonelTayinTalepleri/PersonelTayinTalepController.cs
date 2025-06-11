using Application.Features.PersonelTayinTalepleri.Command.Cancel.CanselPersonelTayinTalep;
using Application.Features.PersonelTayinTalepleri.Command.Create.CreatePersonelTayinTalep;
using Application.Features.PersonelTayinTalepleri.Command.Delete;
using Application.Features.PersonelTayinTalepleri.Command.Update;
using Application.Features.PersonelTayinTalepleri.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AYEP.PersonelTayinTalepWebApi.Controllers.PersonelTayinTalepleri
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PersonelTayinTalepController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("{personelId}")]
        public async Task<ActionResult<IResult>> GetByPersonelId(int personelId)
        {
            var result = await _mediator.Send(new GetPersonelTayinTalepleriByPersonelIdQuery(personelId));
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<IResult>> Create([FromBody] CreatePersonelTayinTalepCommand command)
        {
            var result = await _mediator.Send(command);
            return StatusCode(201, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<IResult>> Update(int id, [FromBody] UpdatePersonelTayinTalepCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IResult>> Delete(int id)
        {
            var result = await _mediator.Send(new DeletePersonelTayinTalepCommand { Id = id });
            return Ok(result);
        }

        [HttpPost("{id}/cancel")]
        public async Task<ActionResult<IResult>> Cancel(int id)
        {
            var result = await _mediator.Send(new CancelPersonelTayinTalepCommand { Id = id });
            return Ok(result);
        }
    }
}
