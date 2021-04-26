namespace VxTelApi.Models
{
    public class ResultadoTarifa
    {
        public string Origem { get; set; }
        public string Destino { get; set; }
        public int Tempo { get; set; }
        public string Plano { get; set; }
        public decimal ComFaleMais { get; set; }
        public decimal SemFaleMais { get; set; }
    }
}
