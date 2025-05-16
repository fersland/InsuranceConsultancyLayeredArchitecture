using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSG_ADMINPRO.DATA.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NombreCliente = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Edad = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Clientes__3214EC076928CF58", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEstado = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Estados__3214EC0779078810", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seguros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NombreSeguro = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Asegurada = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Prima = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Seguros__3214EC078F019190", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreServicio = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    CitaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaActualizcion = table.Column<DateTime>(type: "datetime", nullable: true),
                    Motivo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Notas = table.Column<string>(type: "text", nullable: true),
                    Ubicacion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Citas__F0E2D9D2A825B1FB", x => x.CitaId);
                    table.ForeignKey(
                        name: "FK__Citas__ClienteId__46B27FE2",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Citas__EstadoId__4A8310C6",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tickets_Tipos",
                columns: table => new
                {
                    TicketTpoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTicketTipo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    TicketTipoEstado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tickets___C5CCEC49B27E2DAC", x => x.TicketTpoId);
                    table.ForeignKey(
                        name: "FK__Tickets_T__Ticke__2DE6D218",
                        column: x => x.TicketTipoEstado,
                        principalTable: "Estados",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    CorreoUsuario = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    ClaveUsuario = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    FechaCrecion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuarios__3214EC0754151AEE", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Usuarios__Estado__2B0A656D",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Asegurados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    SeguroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Asegurad__3214EC077F9F108A", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Asegurado__Clien__22751F6C",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Asegurado__Segur__236943A5",
                        column: x => x.SeguroId,
                        principalTable: "Seguros",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    ConsultaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CitaId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    Hora = table.Column<TimeOnly>(type: "time", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaActualizcion = table.Column<DateTime>(type: "datetime", nullable: true),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Resolucion = table.Column<string>(type: "text", nullable: false),
                    Notas = table.Column<string>(type: "text", nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Consulta__7D0B7DCC6A475DD4", x => x.ConsultaId);
                    table.ForeignKey(
                        name: "FK__Consultas__CitaI__4D5F7D71",
                        column: x => x.CitaId,
                        principalTable: "Citas",
                        principalColumn: "CitaId");
                    table.ForeignKey(
                        name: "FK__Consultas__Estad__4E53A1AA",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Fecha_Creacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    Fecha_Actualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    Fecha_Resolucion = table.Column<DateTime>(type: "datetime", nullable: true),
                    TipoTicketId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    Prioridad = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Asunto = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Descripcion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tickets__3214EC0756210803", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Tickets__Descrip__30C33EC3",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Tickets__EstadoI__32AB8735",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Tickets__Usuario__31B762FC",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tickets_Comentarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Fecha_comentario = table.Column<DateTime>(type: "datetime", nullable: false),
                    Comentario = table.Column<string>(type: "text", nullable: false),
                    TicketComentarioEstado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tickets___3214EC07E6AA8E45", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Tickets_C__Ticke__3587F3E0",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Tickets_C__Ticke__37703C52",
                        column: x => x.TicketComentarioEstado,
                        principalTable: "Estados",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Tickets_C__Usuar__367C1819",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asegurados_ClienteId",
                table: "Asegurados",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Asegurados_SeguroId",
                table: "Asegurados",
                column: "SeguroId");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_ClienteId",
                table: "Citas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_EstadoId",
                table: "Citas",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_CitaId",
                table: "Consultas",
                column: "CitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_EstadoId",
                table: "Consultas",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ClienteId",
                table: "Tickets",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EstadoId",
                table: "Tickets",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UsuarioId",
                table: "Tickets",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Comentarios_TicketComentarioEstado",
                table: "Tickets_Comentarios",
                column: "TicketComentarioEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Comentarios_TicketId",
                table: "Tickets_Comentarios",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Comentarios_UsuarioId",
                table: "Tickets_Comentarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Tipos_TicketTipoEstado",
                table: "Tickets_Tipos",
                column: "TicketTipoEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EstadoId",
                table: "Usuarios",
                column: "EstadoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asegurados");

            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Tickets_Comentarios");

            migrationBuilder.DropTable(
                name: "Tickets_Tipos");

            migrationBuilder.DropTable(
                name: "Seguros");

            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Estados");
        }
    }
}
