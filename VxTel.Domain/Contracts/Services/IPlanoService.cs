using System.Threading.Tasks;
using VxTel.Domain.Dto;

namespace VxTel.Domain.Contracts.Services
{
    public interface IPlanoService : IService<PlanoDto>
    {
        Task<PlanoDto> GetPlanoByNome(string nome);
    }
}