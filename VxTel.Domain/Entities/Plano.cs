namespace VxTel.Domain.Entities
{
    public class Plano : Entity
    {
        public Plano() { }
        public Plano(string nomePlano, int minutosFranquia, decimal acrescimoAlemFranquia)
        {
            NomePlano = nomePlano;
            MinutosFranquia = minutosFranquia;
            AcrescimoAlemFranquia = acrescimoAlemFranquia;
        }

        public string NomePlano { get; }
        public int MinutosFranquia { get; }
        public decimal AcrescimoAlemFranquia { get; }

    }
}