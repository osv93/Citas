using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CitasClientes.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    PacienteID = table.Column<string>(nullable: false),
                    PacienteFullName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.PacienteID);
                });

            migrationBuilder.CreateTable(
                name: "TiposCitas",
                columns: table => new
                {
                    TipoCitaID = table.Column<int>(nullable: false),
                    TipoCitaNombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposCitas", x => x.TipoCitaID);
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    CitaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteID = table.Column<string>(nullable: false),
                    TipoCitaID = table.Column<int>(nullable: false),
                    Activa = table.Column<bool>(nullable: false, defaultValue: true),
                    FechaCita = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.CitaID);
                    table.ForeignKey(
                        name: "FK_Citas_Pacientes_PacienteID",
                        column: x => x.PacienteID,
                        principalTable: "Pacientes",
                        principalColumn: "PacienteID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citas_TiposCitas_TipoCitaID",
                        column: x => x.TipoCitaID,
                        principalTable: "TiposCitas",
                        principalColumn: "TipoCitaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pacientes",
                columns: new[] { "PacienteID", "PacienteFullName" },
                values: new object[,]
                {
                    { "1111", "Paciente 1" },
                    { "2222", "Paciente 2" },
                    { "3333", "Paciente 3" },
                    { "4444", "Paciente 4" }
                });

            migrationBuilder.InsertData(
                table: "TiposCitas",
                columns: new[] { "TipoCitaID", "TipoCitaNombre" },
                values: new object[,]
                {
                    { 1, "Medicina General" },
                    { 2, "Odontología" },
                    { 3, "Pediatría" },
                    { 4, "Neurología" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citas_PacienteID",
                table: "Citas",
                column: "PacienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_TipoCitaID",
                table: "Citas",
                column: "TipoCitaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "TiposCitas");
        }
    }
}
