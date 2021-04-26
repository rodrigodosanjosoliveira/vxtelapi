using System;

namespace VxTel.Domain.Entities
{
    public class VxTelChamada : Entity
    {
        public VxTelChamada(string origem, string destino, decimal valorPorMinuto)
        {
            Origem = origem;
            Destino = destino;
            ValorPorMinuto = valorPorMinuto;
        }
        public string Origem { get; }
        public string Destino { get; }

        public decimal ValorPorMinuto { get; }

        public decimal CalcularValorChamada(int duracaoChamada) => duracaoChamada * ValorPorMinuto;

        public decimal CalcularValorChamadaComPlano(int duracaoChamada, Plano plano = null)
        {
            if (plano == null) throw new ArgumentException("Plano inválido");

            var valorChamada = duracaoChamada <= plano.MinutosFranquia ? 0M : AplicaAcrescimoValorMinuto(duracaoChamada, plano);

            return valorChamada;
        }

        private decimal AplicaAcrescimoValorMinuto(int duracaoChamada, Plano plano)
        {
            var minutosAlemFranquia = duracaoChamada - plano.MinutosFranquia;

            var valorChamada = minutosAlemFranquia *
                               (ValorPorMinuto + ValorPorMinuto * plano.AcrescimoAlemFranquia);
            return valorChamada;
        }

    }
}
