using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSG_ADMINPRO.DATA.Migrations
{
    /// <inheritdoc />
    public partial class AddPolizaReclamacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Polizas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    SeguroId = table.Column<int>(type: "int", nullable: false),
                    NumeroPoliza = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime", nullable: false),
                    MontoAsegurado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Prima = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Notas = table.Column<string>(type: "text", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polizas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Polizas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Polizas_Seguros_SeguroId",
                        column: x => x.SeguroId,
                        principalTable: "Seguros",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reclamaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolizaId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    FechaReclamacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    MontoReclamado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Estado = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Resolucion = table.Column<string>(type: "text", nullable: true),
                    FechaResolucion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reclamaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reclamaciones_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reclamaciones_Polizas_PolizaId",
                        column: x => x.PolizaId,
                        principalTable: "Polizas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Polizas_ClienteId",
                table: "Polizas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Polizas_SeguroId",
                table: "Polizas",
                column: "SeguroId");

            migrationBuilder.CreateIndex(
                name: "IX_Reclamaciones_ClienteId",
                table: "Reclamaciones",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reclamaciones_PolizaId",
                table: "Reclamaciones",
                column: "PolizaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reclamaciones");

            migrationBuilder.DropTable(
                name: "Polizas");
        }
    }
}
