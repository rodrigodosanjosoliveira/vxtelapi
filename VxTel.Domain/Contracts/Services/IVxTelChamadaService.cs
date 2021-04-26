using System.Threading.Tasks;
using VxTel.Domain.Dto;

namespace VxTel.Domain.Contracts.Services
{
    public interface IVxTelChamadaService
    {
        Task<(decimal valorComPlano, decimal valorSemPlano)> CalcularValorChamadaAsync(
            ConsultaValorChamadaDto consultaValorChamada);
    }
}
