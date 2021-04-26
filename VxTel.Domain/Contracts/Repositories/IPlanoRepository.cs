using System.Threading.Tasks;
using VxTel.Domain.Entities;

namespace VxTel.Domain.Contracts.Repositories
{
    public interface IPlanoRepository : IRepository<Plano>
    {
        Task<Plano> GetPlanoByName(string nome);
    }
}