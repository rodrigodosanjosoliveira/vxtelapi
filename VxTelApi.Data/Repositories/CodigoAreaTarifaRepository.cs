using System.Linq;
using VxTel.Domain.Contracts.Repositories;
using VxTel.Domain.Entities;
using VxTelApi.Data.Context;

namespace VxTelApi.Data.Repositories
{
    public class CodigoAreaTarifaRepository : Repository<CodigoAreaTarifa>, ICodigoAreaTarifaRepository
    {
        public CodigoAreaTarifaRepository(VxTelContext context) : base(context) { }

        public decimal GetTarifa(string origem, string destino)
        {
            var tarifa = GetAll().FirstOrDefault(t => origem.Equals(t.CodigoOrigem)
                                                      && destino.Equals(t.CodigoDestino)).ValorPorMinuto;
            return tarifa;
        }
    }
}