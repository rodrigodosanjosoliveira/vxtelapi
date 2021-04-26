using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VxTel.Domain.Contracts.Repositories;
using VxTel.Domain.Entities;
using VxTelApi.Data.Context;

namespace VxTelApi.Data.Repositories
{
    public class PlanoRepository : Repository<Plano>, IPlanoRepository
    {
        public PlanoRepository(VxTelContext context) : base(context)
        {
        }

        public async Task<Plano> GetPlanoByName(string nome)
        {
            var plano = await GetAll().FirstOrDefaultAsync(p => nome.Equals(p.NomePlano));
            return plano;
        }
    }
}