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
    public class CodigoAreaTarifaRepositoryTests
    {
        [Fact]
        public async void CodigoAreaTarifaRepository_Add_CodigoAreaTarifa()
        {
            var sut = GetInMemoryCodigoAreaTarifaRepository();
            var codigoAreaTarifa = new CodigoAreaTarifa("021", "011", 2M);

            var codigoAreaTarifaSaved = await sut.Create(codigoAreaTarifa);

            Assert.Equal(7, sut.GetAll().Count());
            Assert.Equal("021", codigoAreaTarifaSaved.CodigoOrigem);
            Assert.Equal("011", codigoAreaTarifaSaved.CodigoDestino);
            Assert.Equal(2M, codigoAreaTarifaSaved.ValorPorMinuto);

        }

        [Fact]
        public async Task CodigoAreaTarifaRepository_GetAll_()
        {
            var sut = GetInMemoryCodigoAreaTarifaRepository();

            CodigoAreaTarifa[] tarifas;

            tarifas = await sut.GetAll().ToArrayAsync();

            Assert.True(tarifas.Any());
            Assert.Equal(6, tarifas.Length);

        }


        [Fact]
        public void CodigoAreaTarifaRepository_GetTarifa()
        {
            var sut = GetInMemoryCodigoAreaTarifaRepository();

            var tarifa = sut.GetTarifa("011", "016");

            Assert.Equal(1.9M, tarifa);
        }

        private static ICodigoAreaTarifaRepository GetInMemoryCodigoAreaTarifaRepository()
        {
            var builder = new DbContextOptionsBuilder<VxTelContext>();
            builder.UseInMemoryDatabase("testdb");
            var options = builder.Options;
            var context = new VxTelContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            return new CodigoAreaTarifaRepository(context);
        }
    }
}
