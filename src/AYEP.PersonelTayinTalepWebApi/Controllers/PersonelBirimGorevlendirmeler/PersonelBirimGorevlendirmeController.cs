using Application.Features.PersonelBirimGorevlendirmeler.Command.Create;
using Application.Features.PersonelBirimGorevlendirmeler.Command.Delete;
using Application.Features.PersonelBirimGorevlendirmeler.Command.Update;
using Application.Features.PersonelBirimGorevlendirmeler.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AYEP.PersonelTayinTalepWebApi.Controllers.PersonelBirimGorevlendirmeler
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonelBirimGorevlendirmeController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult<IResult>> GetAll()
        {
            var result = await _mediator.Send(new GetAllPersonelBirimGorevlendirmeQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IResult>> GetById(int id)
        {
            var result = await _mediator.Send(new GetPersonelBirimGorevlendirmeByIdQuery { Id = id });            
            return Ok(result);
        }

        [HttpGet("by-personel/{personelId}")]
        public async Task<ActionResult<IResult>> GetByPersonelId(int personelId)
        {
            var result = await _mediator.Send(new GetPersonelBirimGorevlendirmelerByPersonelIdQuery { PersonelId = personelId });
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<IResult>> Create([FromBody] CreatePersonelBirimGorevlendirmeCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<IResult>> Update(int id, [FromBody] UpdatePersonelBirimGorevlendirmeCommand command)
        {
            if (id != command.Id)
                return BadRequest("Id uyuşmuyor.");
            var result = await _mediator.Send(command);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IResult>> Delete(int id)
        {
            var result = await _mediator.Send(new DeletePersonelBirimGorevlendirmeCommand { Id = id });
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }
    }
}
