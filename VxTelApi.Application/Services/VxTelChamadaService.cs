using System.Threading.Tasks;
using VxTel.Domain.Contracts.Repositories;
using VxTel.Domain.Contracts.Services;
using VxTel.Domain.Dto;
using VxTel.Domain.Entities;

namespace VxTelApi.Application.Services
{
    public class VxTelChamadasService : IVxTelChamadaService
    {
        private readonly ICodigoAreaTarifaRepository _codigoAreaTarifaRepository;
        private readonly IPlanoRepository _planoRepository;

        public VxTelChamadasService(ICodigoAreaTarifaRepository codigoAreaTarifaRepository, IPlanoRepository planoRepository)
        {
            _codigoAreaTarifaRepository = codigoAreaTarifaRepository;
            _planoRepository = planoRepository;
        }
        public async Task<(decimal valorComPlano, decimal valorSemPlano)> CalcularValorChamadaAsync(ConsultaValorChamadaDto consultaValorChamada)
        {
            var tarifa = _codigoAreaTarifaRepository.GetTarifa(consultaValorChamada.CodigoAreaOrigem, consultaValorChamada.CodigoAreaDestino);
            var chamada = new VxTelChamada(consultaValorChamada.CodigoAreaOrigem, consultaValorChamada.CodigoAreaDestino, tarifa);

            var plano = await _planoRepository.GetPlanoByName(consultaValorChamada.Plano);

            var valorComPlano =
                chamada.CalcularValorChamadaComPlano(consultaValorChamada.DuracaoChamada, plano);

            var valorSemPlano = chamada.CalcularValorChamada(consultaValorChamada.DuracaoChamada);

            return (valorComPlano: valorComPlano, valorSemPlano: valorSemPlano);
        }
    }
}