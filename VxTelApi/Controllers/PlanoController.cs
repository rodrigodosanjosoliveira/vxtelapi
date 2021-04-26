using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using VxTel.Domain.Contracts.Services;
using VxTel.Domain.Dto;

namespace VxTelApi.Controllers
{
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    public class PlanoController : Controller
    {
        private readonly IPlanoService _planoService;
        private readonly ILogger<PlanoController> _logger;
        public PlanoController(IPlanoService planoService, ILogger<PlanoController> logger)
        {
            _planoService = planoService;
            _logger = logger;
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IEnumerable<PlanoDto> GetAll()
        {
            return _planoService.GetAll();
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CodigoAreaTarifaDto>> Get(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("Parâmetro inválido");

            var plano = await _planoService.GetById(id);

            if (plano == null)
                return NotFound("Plano não encontrado");

            return Ok(plano);
        }

        [HttpGet("{nome}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetByNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                return BadRequest("Parâmetro invalido");

            var plano = await _planoService.GetPlanoByNome(nome);

            if (plano == null)
                return NotFound("Plano não encontrado");

            return Ok(plano);
        }
    }
}
