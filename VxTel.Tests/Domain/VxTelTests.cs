using VxTel.Domain.Entities;
using Xunit;

namespace VxTel.Tests.Domain
{
    public class VxTelTests
    {
        [Fact]
        public void Fazer_Chamada_Sem_Plano()
        {
            var origem = "011";
            var destino = "016";
            var duracaoChamada = 1;
            var tarifa = 1.9M;

            var vxTel = new VxTelChamada(origem, destino,tarifa);
            var valorDaChamada = vxTel.CalcularValorChamada(duracaoChamada);

            Assert.Equal(1.9M, valorDaChamada);

        }

        [Fact]
        public void Fazer_Chamada_Com_Plano_Mais30_Sem_Exceder_Franquia()
        {
            var origem = "011";
            var destino = "016";
            var duracaoChamada = 30;
            var tarifa = 1.9M;
            var plano = new Plano("FaleMais 30", 30, 0.1M);

            var vxTel = new VxTelChamada(origem, destino,tarifa);
            var valorDaChamada = vxTel.CalcularValorChamadaComPlano(duracaoChamada,plano);

            Assert.Equal(0, valorDaChamada);
        }

        [Fact]
        public void Fazer_Chamada_Com_Plano_Mais60_Sem_Exceder_Franquia()
        {
            var origem = "011";
            var destino = "018";
            var duracaoChamada = 60;
            var tarifa = 0.9M;
            var plano = new Plano("FaleMais 60", 60, 0.1M);

            var vxTel = new VxTelChamada(origem, destino,tarifa);
            var valorDaChamada = vxTel.CalcularValorChamadaComPlano(duracaoChamada, plano);

            Assert.Equal(0M, valorDaChamada);
        }

        [Fact]
        public void Fazer_Chamada_Com_Plano_Mais120_Sem_Exceder_Franquia()
        {
            var origem = "011";
            var destino = "018";
            var duracaoChamada = 120;
            var tarifa = 0.9M;
            var plano = new Plano("FaleMais 120", 120, 0.1M);

            var vxTel = new VxTelChamada(origem, destino,tarifa);
            var valorDaChamada = vxTel.CalcularValorChamadaComPlano(duracaoChamada, plano);

            Assert.Equal(0M, valorDaChamada);
        }

        [Fact]
        public void Fazer_Chamada_Com_Plano_Mais30_Excedendo_Franquia()
        {
            var origem = "011";
            var destino = "018";
            var duracaoChamada = 40;
            var tarifa = 0.9M;
            var plano = new Plano("FaleMais 30", 30, 0.1M);

            var vxTel = new VxTelChamada(origem, destino,tarifa);
            var valorDaChamada = vxTel.CalcularValorChamadaComPlano(duracaoChamada, plano);

            Assert.Equal(9.9M, valorDaChamada);
        }

        [Fact]
        public void Fazer_Chamada_Com_Plano_Mais60_Excedendo_Franquia()
        {
            var origem = "011";
            var destino = "018";
            var duracaoChamada = 80;
            var tarifa = 0.9M;
            var plano = new Plano("FaleMais 60", 60, 0.1M);

            var vxTel = new VxTelChamada(origem, destino,tarifa);
            var valorDaChamada = vxTel.CalcularValorChamadaComPlano(duracaoChamada, plano);

            Assert.Equal(19.8M, valorDaChamada);
        }

        [Fact]
        public void Fazer_Chamada_Com_Plano_Mais120_Excedendo_Franquia()
        {
            var origem = "018";
            var destino = "011";
            var duracaoChamada = 200;
            var tarifa = 1.9M;
            var plano = new Plano("FaleMais 120", 120, 0.1M);

            var vxTel = new VxTelChamada(origem, destino,tarifa);
            var valorDaChamada = vxTel.CalcularValorChamadaComPlano(duracaoChamada, plano);

            Assert.Equal(167.2M, valorDaChamada);
        }
    }
}
