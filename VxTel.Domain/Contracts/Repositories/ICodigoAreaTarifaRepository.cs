using VxTel.Domain.Entities;

namespace VxTel.Domain.Contracts.Repositories
{
    public interface ICodigoAreaTarifaRepository : IRepository<CodigoAreaTarifa>
    {
        decimal GetTarifa(string origem, string destino);
    }
}