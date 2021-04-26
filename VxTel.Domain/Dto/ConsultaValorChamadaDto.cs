namespace VxTel.Domain.Dto
{
    public class ConsultaValorChamadaDto
    {
        public string CodigoAreaOrigem { get; set; }
        public string CodigoAreaDestino { get; set; }
        public int DuracaoChamada { get; set; }
        public string Plano { get; set; }
    }
}