using System;
using System.Collections.Generic;
using System.Linq;
using VxTel.Domain.Entities;

namespace VxTel.Domain.Dto
{
    public class CodigoAreaTarifaDto
    {
        public CodigoAreaTarifaDto() { }

        public CodigoAreaTarifaDto(CodigoAreaTarifa tarifa)
        {
            Id = tarifa.Id;
            CodigoOrigem = tarifa.CodigoOrigem;
            CodigoDestino = tarifa.CodigoDestino;
            ValorPorMinuto = tarifa.ValorPorMinuto;
        }

        public Guid? Id { get; set; }
        public string CodigoOrigem { get; set; }
        public string CodigoDestino { get; set; }
        public decimal ValorPorMinuto { get; set; }

        public static List<CodigoAreaTarifaDto> Convert(List<CodigoAreaTarifa> tarifas)
            => tarifas.Select(tarifa => new CodigoAreaTarifaDto(tarifa)).ToList();
    }
}