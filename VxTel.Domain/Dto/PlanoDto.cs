using System;
using VxTel.Domain.Entities;

namespace VxTel.Domain.Dto
{
    public class PlanoDto
    {
        public PlanoDto() { }
        public PlanoDto(Plano plano)
        {
            Id = plano.Id;
            NomePlano = plano.NomePlano;
            MinutosFranquia = plano.MinutosFranquia;
            AcrescimoAlemFranquia = plano.AcrescimoAlemFranquia;
        }

        public Guid? Id { get; set; }
        public string NomePlano { get; }
        public int MinutosFranquia { get; }
        public decimal AcrescimoAlemFranquia { get; }
    }
}