using VxTel.Domain.Entities;
using Xunit;

namespace VxTel.Tests.Domain
{
    public class SimulatorTests
    {
        [Fact]
        public void Simular_Valor_Chamada_Com_Plano_FaleMais30()
        {
            var origem = "011";
            var destino = "016";
            var duracaoChamada = 20;
            var tarifa = 1.9M;
            var plano = new Plano("FaleMais 30", 30, 0.1M);

            var vxTel = new VxTelChamada(origem, destino, tarifa);
            var valorDaChamada = vxTel.CalcularValorChamadaComPlano(duracaoChamada,plano);

            Assert.Equal(0M, valorDaChamada);

        }

        [Fact]
        public void Simular_Valor_Chamada_Sem_Plano_FaleMais30()
        {
            var origem = "011";
            var destino = "016";
            var duracaoChamada = 20;
            var tarifa = 1.9M;

            var vxTel = new VxTelChamada(origem, destino, tarifa);
            var valorDaChamada = vxTel.CalcularValorChamada(duracaoChamada);

            Assert.Equal(38M, valorDaChamada);

        }

        [Fact]
        public void Simular_Valor_Chamada_Com_Plano_FaleMais60()
        {
            var origem = "011";
            var destino = "017";
            var duracaoChamada = 80;
            var plano = new Plano("FaleMais 60", 60, 0.1M); 
            var tarifa = 1.7M;

            var vxTel = new VxTelChamada(origem, destino, tarifa);
            var valorDaChamada = vxTel.CalcularValorChamadaComPlano(duracaoChamada, plano);

            Assert.Equal(37.4M, valorDaChamada);

        }

        [Fact]
        public void Simular_Valor_Chamada_Sem_Plano_FaleMais60()
        {
            var origem = "011";
            var destino = "016";
            var duracaoChamada = 20;
            var tarifa = 1.9M;

            var vxTel = new VxTelChamada(origem, destino, tarifa);
            var valorDaChamada = vxTel.CalcularValorChamada(duracaoChamada);

            Assert.Equal(38M, valorDaChamada);

        }

        [Fact]
        public void Simular_Valor_Chamada_Com_Plano_FaleMais120()
        {
            var origem = "018";
            var destino = "011";
            var duracaoChamada = 200;
            var plano = new Plano("FaleMais 120", 120, 0.1M);
            var tarifa = 1.9M;

            var vxTel = new VxTelChamada(origem, destino, tarifa);
            var valorDaChamada = vxTel.CalcularValorChamadaComPlano(duracaoChamada, plano);

            Assert.Equal(167.2M, valorDaChamada);

        }

        [Fact]
        public void Simular_Valor_Chamada_Sem_Plano_FaleMais120()
        {
            var origem = "018";
            var destino = "011";
            var duracaoChamada = 200;
            var tarifa = 1.9M;

            var vxTel = new VxTelChamada(origem, destino, tarifa);
            var valorDaChamada = vxTel.CalcularValorChamada(duracaoChamada);

            Assert.Equal(380M, valorDaChamada);

        }
    }
}
