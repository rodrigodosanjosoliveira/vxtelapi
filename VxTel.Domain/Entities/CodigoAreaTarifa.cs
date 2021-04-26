namespace VxTel.Domain.Entities
{
    public class CodigoAreaTarifa : Entity
    {
        public CodigoAreaTarifa() { }

        public CodigoAreaTarifa(string origem, string destino, decimal valorPorMinuto)
        {
            CodigoOrigem = origem;
            CodigoDestino = destino;
            ValorPorMinuto = valorPorMinuto;
        }

        public string CodigoOrigem { get; }
        public string CodigoDestino { get; }
        public decimal ValorPorMinuto { get;}
    }
}
