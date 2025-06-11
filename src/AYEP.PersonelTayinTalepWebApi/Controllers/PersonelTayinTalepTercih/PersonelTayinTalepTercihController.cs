using Application.Features.PersonelTayinTalepleri.Command.Create.PersonelTayinTalepTercih;
using Application.Features.PersonelTayinTalepleri.Command.Delete.PersonelTayinTalepTercih;
using Application.Features.PersonelTayinTalepleri.Command.Update.PersonelTayinTalepTercih;
using Application.Features.PersonelTayinTalepleri.Queries.PersonelTayinTalepTercih;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AYEP.PersonelTayinTalepWebApi.Controllers.PersonelTayinTalepTercih
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PersonelTayinTalepTercihController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        
        [HttpGet("ByTalep/{talepId}")]
        public async Task<ActionResult<IResult>> GetByTalepId(int talepId)
        {
            var result = await _mediator.Send(new GetPersonelTayinTalepTercihlerByTalepIdQuery(talepId));
            return Ok(result);
        }
       
        [HttpPost]
        public async Task<ActionResult<IResult>> Create([FromBody] CreatePersonelTayinTalepTercihCommand command)
        {
            var result = await _mediator.Send(command);
            return StatusCode(201, result);
        }
       
        [HttpPut("{id}")]
        public async Task<ActionResult<IResult>> Update(int id, [FromBody] UpdatePersonelTayinTalepTercihCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IResult>> Delete(int id)
        {
            var result = await _mediator.Send(new DeletePersonelTayinTalepTercihCommand { Id = id });
            return Ok(result);
        }
    }
}
