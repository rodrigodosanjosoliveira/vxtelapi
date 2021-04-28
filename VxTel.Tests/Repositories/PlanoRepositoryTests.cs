using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VxTel.Domain.Contracts.Repositories;
using VxTel.Domain.Entities;
using VxTelApi.Data.Context;
using VxTelApi.Data.Repositories;
using Xunit;

namespace VxTel.Tests.Repositories
{
    public class PlanoRepositoryTests
    {


        [Fact]
        public async Task PlanoRepository_GetPlanoByNome_Plano_Nome_Valido()
        {
            var sut = GetInMemoryPlanoRepository();

            Plano plano;

            plano = await sut.GetPlanoByName("FaleMais 30");

            Assert.Equal("FaleMais 30", plano.NomePlano);
            Assert.Equal(30, plano.MinutosFranquia);
        }

        [Fact]
        public async Task PlanoRepository_GetAll_Plano()
        {
            var sut = GetInMemoryPlanoRepository();

            Plano[] planos;

            planos = await sut.GetAll().ToArrayAsync();
            
            Assert.True(planos.Any());
            Assert.Equal(3, planos.Length);

        }

        [Fact]
        public async void PlanoRepository_Add_Plano()
        {
            var sut = GetInMemoryPlanoRepository();

            var novoPlano = await sut.Create(new Plano("FaleMais 90", 90, 0.1M));

            Assert.Equal(4, sut.GetAll().Count());
            Assert.Equal("FaleMais 90", novoPlano.NomePlano);
            Assert.Equal(90, novoPlano.MinutosFranquia);
            Assert.Equal(0.1M, novoPlano.AcrescimoAlemFranquia);

        }

        private static IPlanoRepository GetInMemoryPlanoRepository()
        {
            var builder = new DbContextOptionsBuilder<VxTelContext>();
            builder.UseInMemoryDatabase("testdb");
            var options = builder.Options;
            var context = new VxTelContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            return new PlanoRepository(context);
        }

    }
}
