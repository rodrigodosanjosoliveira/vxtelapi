using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VxTelApi.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plano",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomePlano = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinutosFranquia = table.Column<int>(type: "int", nullable: false),
                    AcrescimoAlemFranquia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plano", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tarifa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodigoOrigem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoDestino = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorPorMinuto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarifa", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Plano",
                columns: new[] { "Id", "AcrescimoAlemFranquia", "DateCreated", "DateUpdated", "MinutosFranquia", "NomePlano" },
                values: new object[,]
                {
                    { new Guid("d087ba13-4a23-4875-90a2-2f1bbb6be14e"), 0.1m, new DateTime(2021, 4, 25, 22, 1, 41, 736, DateTimeKind.Local).AddTicks(1751), null, 30, "FaleMais 30" },
                    { new Guid("f1d612c7-35ed-4fa5-baa6-094976289d44"), 0.1m, new DateTime(2021, 4, 25, 22, 1, 41, 736, DateTimeKind.Local).AddTicks(1770), null, 60, "FaleMais 60" },
                    { new Guid("17d6fbc3-4546-459d-8b30-99a472ffad54"), 0.1m, new DateTime(2021, 4, 25, 22, 1, 41, 736, DateTimeKind.Local).AddTicks(1784), null, 120, "FaleMais 120" }
                });

            migrationBuilder.InsertData(
                table: "Tarifa",
                columns: new[] { "Id", "CodigoDestino", "CodigoOrigem", "DateCreated", "DateUpdated", "ValorPorMinuto" },
                values: new object[,]
                {
                    { new Guid("c2706236-88c6-46cd-b2f7-d4b17ed31733"), "016", "011", new DateTime(2021, 4, 25, 22, 1, 41, 731, DateTimeKind.Local).AddTicks(8926), null, 1.9m },
                    { new Guid("c053d14c-363a-4154-ad0b-7bdc48a1a10f"), "011", "016", new DateTime(2021, 4, 25, 22, 1, 41, 734, DateTimeKind.Local).AddTicks(2057), null, 2.9m },
                    { new Guid("4d6645ef-4a28-424a-ad00-c15143d98be4"), "017", "011", new DateTime(2021, 4, 25, 22, 1, 41, 734, DateTimeKind.Local).AddTicks(2083), null, 1.7m },
                    { new Guid("5ee2dee9-b0f7-4884-ac1b-cdb5536d7b8c"), "011", "017", new DateTime(2021, 4, 25, 22, 1, 41, 734, DateTimeKind.Local).AddTicks(2088), null, 2.7m },
                    { new Guid("0948684a-9976-4d61-943c-910c6dd18119"), "018", "011", new DateTime(2021, 4, 25, 22, 1, 41, 734, DateTimeKind.Local).AddTicks(2091), null, 0.9m },
                    { new Guid("266fffb9-e91d-4175-8fbe-85a57c25bfd9"), "011", "018", new DateTime(2021, 4, 25, 22, 1, 41, 734, DateTimeKind.Local).AddTicks(2095), null, 1.9m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plano");

            migrationBuilder.DropTable(
                name: "Tarifa");
        }
    }
}
