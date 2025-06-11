using Application.Features.Birimler.Command.Create;
using Application.Features.Birimler.Command.Delete;
using Application.Features.Birimler.Command.Update;
using Application.Features.Birimler.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AYEP.PersonelTayinTalepWebApi.Controllers.Birimler
{
    [ApiController]
    [Route("api/[controller]")]
    public class BirimController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// Tüm birimleri listeler.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IResult>> GetAll()
        {
            var result = await _mediator.Send(new GetAllBirimlerQuery());
            return Ok(result);
        }

        /// <summary>
        /// Id ile birim getirir.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<IResult>> GetById(int id)
        {
            var result = await _mediator.Send(new GetBirimByIdQuery { Id = id });
            return Ok(result);
        }

        /// <summary>
        /// Adliye id'ye bağlı birimleri getirir.
        /// </summary>
        [HttpGet("by-adliye/{adliyeId}")]
        public async Task<ActionResult<IResult>> GetByAdliye(int adliyeId)
        {
            var result = await _mediator.Send(new GetBirimlerByAdliyeIdQuery { AdliyeId = adliyeId });
            return Ok(result);
        }

        /// <summary>
        /// Yeni birim oluşturur.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<IResult>> Create([FromBody] CreateBirimCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        /// <summary>
        /// Birimi günceller.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<IResult>> Update(int id, [FromBody] UpdateBirimCommand command)
        {
            if (id != command.Id)
                return BadRequest("Id uyuşmuyor.");
            var result = await _mediator.Send(command);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        /// <summary>
        /// Birimi siler.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteBirimCommand { Id = id });
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }
    }
}
