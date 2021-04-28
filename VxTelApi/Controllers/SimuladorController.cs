using System;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VxTel.Domain.Contracts.Services;
using VxTel.Domain.Dto;
using VxTelApi.Models;

namespace VxTelApi.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    public class SimuladorController : Controller
    {
        private readonly IVxTelChamadaService _chamadaService;
        private readonly ILogger<SimuladorController> _logger;

        public SimuladorController(IVxTelChamadaService chamadaService, ILogger<SimuladorController> logger)
        {
            _chamadaService = chamadaService;
            _logger = logger;
        }

        [HttpPost("tarifa")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CalcularTarifa([FromBody] ConsultaTarifas consulta)
        {
            if (consulta == null || !ModelState.IsValid) return BadRequest("Parâmetros inválidos");

            try
            {
                var valores = await _chamadaService.CalcularValorChamadaAsync(new ConsultaValorChamadaDto
                {
                    CodigoAreaOrigem = consulta.CodigoAreaOrigem,
                    CodigoAreaDestino = consulta.CodigoAreaDestino,
                    DuracaoChamada = consulta.DuracaoChamada,
                    Plano = consulta.Plano
                });

                var resultado = new ResultadoTarifa
                {
                    Origem = consulta.CodigoAreaOrigem,
                    Destino = consulta.CodigoAreaDestino,
                    ComFaleMais = valores.valorComPlano,
                    SemFaleMais = valores.valorSemPlano,
                    Plano = consulta.Plano,
                    Tempo = consulta.DuracaoChamada
                };

                return Ok(resultado);
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro: {e.Message}");
                return BadRequest();
            }
        }
    }
}
