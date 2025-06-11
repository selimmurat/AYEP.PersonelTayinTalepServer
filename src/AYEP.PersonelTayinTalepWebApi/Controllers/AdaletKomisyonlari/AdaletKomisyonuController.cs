using Application.Features.AdaletKomisyonlari.Command.Create;
using Application.Features.AdaletKomisyonlari.Command.Delete;
using Application.Features.AdaletKomisyonlari.Command.Update;
using Application.Features.AdaletKomisyonlari.Queries;
using Domain.Shared.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AYEP.PersonelTayinTalepWebApi.Controllers.AdaletKomisyonlari
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdaletKomisyonuController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        // [POST] api/AdaletKomisyonu
        [HttpPost]
        public async Task<ActionResult<IResult>> Create([FromBody] CreateAdaletKomisyonuCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        // [PUT] api/AdaletKomisyonu/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<IResult>> Update(int id, [FromBody] UpdateAdaletKomisyonuCommand command)
        {
            if (id != command.Id)
                return BadRequest("Id uyumsuz.");
            var result = await _mediator.Send(command);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        // [DELETE] api/AdaletKomisyonu/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<IResult>> Delete(int id)
        {
            var command = new DeleteAdaletKomisyonuCommand { Id = id };
            var result = await _mediator.Send(command);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        // [GET] api/AdaletKomisyonu
        [HttpGet]
        public async Task<ActionResult<IResultBase>> GetAll()
        {
            var result = await _mediator.Send(new GetAllAdaletKomisyonuQuery());
            return Ok(result);
        }

        // [GET] api/AdaletKomisyonu/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<IResultBase>> GetById(int id)
        {
            var result = await _mediator.Send(new GetAdaletKomisyonuByIdQuery { Id = id });
            if (!result.Success)
                return NotFound(result.Message);
            return Ok(result);
        }
    }
}
