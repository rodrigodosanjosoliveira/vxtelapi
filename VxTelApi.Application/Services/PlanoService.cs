using System;
using System.Linq;
using System.Threading.Tasks;
using VxTel.Domain.Contracts.Repositories;
using VxTel.Domain.Contracts.Services;
using VxTel.Domain.Dto;
using VxTel.Domain.Entities;

namespace VxTelApi.Application.Services
{
    public class PlanoService : IPlanoService
    {
        private readonly IPlanoRepository _planoRepository;

        public PlanoService(IPlanoRepository planoRepository)
        {
            _planoRepository = planoRepository;
        }

        public IQueryable<PlanoDto> GetAll()
            => _planoRepository.GetAll()
                .Select(p => new PlanoDto(p));

        public async Task<PlanoDto> GetById(Guid id)
        {
            var planoFromDb = await _planoRepository.GetById(id);

            return planoFromDb != null
                ? new PlanoDto(planoFromDb)
                : throw new ArgumentException("Plano não encontrado");
        }

        public async Task<PlanoDto> Create(PlanoDto planoDto)
        {
            var novoPlano =
                new Plano(planoDto.NomePlano, planoDto.MinutosFranquia, planoDto.AcrescimoAlemFranquia);
            var planoCadastrado = await _planoRepository.Create(novoPlano);
            return new PlanoDto(planoCadastrado);
        }

        public async Task<PlanoDto> Update(Guid id, PlanoDto dto)
        {
            var planoAtualizado = new Plano(dto.NomePlano, dto.MinutosFranquia, dto.AcrescimoAlemFranquia);
            var planoAtualizadoDb = await _planoRepository.Update(id, planoAtualizado);

            return new PlanoDto(planoAtualizadoDb);
        }

        public async Task Delete(Guid id)
        {
            await _planoRepository.Delete(id);
        }

        public async Task<PlanoDto> GetPlanoByNome(string nome)
        {
            var plano = await _planoRepository.GetPlanoByName(nome);

            return new PlanoDto(plano);
        }
    }
}