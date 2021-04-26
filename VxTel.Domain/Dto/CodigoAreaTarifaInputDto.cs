namespace VxTel.Domain.Dto
{
    public class CodigoAreaTarifaInputDto
    {
        public string CodigoOrigem { get; set; }
        public string CodigoDestino { get; set; }
        public decimal ValorPorMinuto { get; set; }
    }
}