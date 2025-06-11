using Application.Features.Adliyeler.Command.Create;
using Application.Features.Adliyeler.Command.Delete;
using Application.Features.Adliyeler.Command.Update;
using Application.Features.Adliyeler.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AYEP.PersonelTayinTalepWebApi.Controllers.Adliyeler
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdliyeController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// Tüm adliyeleri listeler.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IResult>> GetAll()
        {
            var result = await _mediator.Send(new GetAllAdliyelerQuery());
            return Ok(result);
        }

        /// <summary>
        /// Id ile adliye getirir.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<IResult>> GetById(int id)
        {
            var result = await _mediator.Send(new GetAdliyeByIdQuery { Id = id });
            if (result.Data == null)
                return NotFound(result.Message);
            return Ok(result);
        }

        /// <summary>
        /// Belirli bir komisyona bağlı adliyeleri getirir.
        /// </summary>
        [HttpGet("by-komisyon/{komisyonId}")]
        public async Task<ActionResult<IResult>> GetByKomisyon(int komisyonId)
        {
            var result = await _mediator.Send(new GetAdliyelerByKomisyonIdQuery { KomisyonId = komisyonId });
            return Ok(result);
        }

        /// <summary>
        /// Yeni adliye oluşturur.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<IResult>> Create([FromBody] CreateAdliyeCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        /// <summary>
        /// Adliyeyi günceller.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<IResult>> Update(int id, [FromBody] UpdateAdliyeCommand command)
        {
            if (id != command.Id)
                return BadRequest("Id uyuşmuyor.");
            var result = await _mediator.Send(command);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        /// <summary>
        /// Adliyeyi siler.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteAdliyeCommand { Id = id });
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }
    }
}
