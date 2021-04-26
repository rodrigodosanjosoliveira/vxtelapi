using System;
using System.Linq;
using System.Threading.Tasks;
using VxTel.Domain.Contracts.Repositories;
using VxTel.Domain.Contracts.Services;
using VxTel.Domain.Dto;
using VxTel.Domain.Entities;

namespace VxTelApi.Application.Services
{
    public class CodigoAreaTarifaService : ICodigoAreaTarifaService
    {
        private readonly ICodigoAreaTarifaRepository _codigoAreaTarifaRepository;

        public CodigoAreaTarifaService(ICodigoAreaTarifaRepository codigoAreaTarifaRepository)
        {
            _codigoAreaTarifaRepository = codigoAreaTarifaRepository;
        }

        public IQueryable<CodigoAreaTarifaDto> GetAll()
            => _codigoAreaTarifaRepository.GetAll()
                .Select(t => new CodigoAreaTarifaDto(t)
                );

        public async Task<CodigoAreaTarifaDto> GetById(Guid id)
        {
            var tarifaFromDb = await _codigoAreaTarifaRepository.GetById(id);

            return tarifaFromDb != null
                ? new CodigoAreaTarifaDto(tarifaFromDb)
                : throw new ArgumentException("Tarifa não encontrada");
        }

        public async Task<CodigoAreaTarifaDto> Create(CodigoAreaTarifaDto tarifaDto)
        {
            var novaTarifa =
                new CodigoAreaTarifa(tarifaDto.CodigoOrigem, tarifaDto.CodigoDestino, tarifaDto.ValorPorMinuto);
            var tarifaCadastrada = await _codigoAreaTarifaRepository.Create(novaTarifa);
            return new CodigoAreaTarifaDto(tarifaCadastrada);
        }

        public async Task<CodigoAreaTarifaDto> Update(Guid id, CodigoAreaTarifaDto dto)
        {
            var tarifaAtualizada = new CodigoAreaTarifa(dto.CodigoOrigem, dto.CodigoDestino, dto.ValorPorMinuto);
            var tarifaAtualizadaDb = await _codigoAreaTarifaRepository.Update(id, tarifaAtualizada);

            return new CodigoAreaTarifaDto(tarifaAtualizadaDb);
        }

        public async Task Delete(Guid id)
        {
            await _codigoAreaTarifaRepository.Delete(id);
        }
    }
}
