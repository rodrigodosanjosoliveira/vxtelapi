using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VxTel.Domain.Contracts.Services;
using VxTel.Domain.Dto;

namespace VxTelApi.Controllers
{
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    public class TarifaController : Controller
    {
        private readonly ICodigoAreaTarifaService _codigoAreaTarifaService;
        private readonly ILogger<TarifaController> _logger;

        public TarifaController(ICodigoAreaTarifaService codigoAreaTarifaService, ILogger<TarifaController> logger)
        {
            _codigoAreaTarifaService = codigoAreaTarifaService;
            _logger = logger;
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IEnumerable<CodigoAreaTarifaDto> GetAll()
        {
            return _codigoAreaTarifaService.GetAll();
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CodigoAreaTarifaDto>> Get(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("Parâmetro inválido");

            var tarifa = await _codigoAreaTarifaService.GetById(id);

            if (tarifa == null)
                return NotFound("Tarifa não encontrada");

            return Ok(tarifa);
        }

        [HttpPost("new")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CodigoAreaTarifaInputDto tarifaInputDto)
        {
            if (tarifaInputDto == null || !ModelState.IsValid)
                return BadRequest(tarifaInputDto);

            var tarifa = new CodigoAreaTarifaDto
            {
                CodigoOrigem = tarifaInputDto.CodigoOrigem,
                CodigoDestino = tarifaInputDto.CodigoDestino,
                ValorPorMinuto = tarifaInputDto.ValorPorMinuto
            };

            try
            {
                var novaTarifa = await _codigoAreaTarifaService.Create(tarifa)
                    .ConfigureAwait(true);
                return CreatedAtAction(nameof(Get), new { id = novaTarifa.Id }, novaTarifa);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpDelete("destroy/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("Parâmetro inválido");

            var tarifa = await _codigoAreaTarifaService.GetById(id);
            
            if (tarifa == null)
                return NotFound("Tarifa não encontrada");

            if (tarifa.Id.HasValue) await _codigoAreaTarifaService.Delete(tarifa.Id.Value);

            return NoContent();
        }
    }
}
