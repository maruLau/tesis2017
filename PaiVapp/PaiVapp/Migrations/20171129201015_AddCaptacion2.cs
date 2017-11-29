using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PaiVapp.Migrations
{
    public partial class AddCaptacion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NBiologico",
                table: "Biologico",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Captacion",
                columns: table => new
                {
                    CaptacionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlerMedic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlergOtros = table.Column<int>(type: "int", nullable: false),
                    AlergVacuna = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlergiaSN = table.Column<int>(type: "int", nullable: false),
                    Barrio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CI = table.Column<int>(type: "int", nullable: false),
                    CICod = table.Column<int>(type: "int", nullable: false),
                    CIMadre = table.Column<int>(type: "int", nullable: false),
                    CIPadreT = table.Column<int>(type: "int", nullable: false),
                    ComIndigena = table.Column<int>(type: "int", nullable: false),
                    DSeguro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartamentoID = table.Column<int>(type: "int", nullable: false),
                    DescOtros = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistritoID = table.Column<int>(type: "int", nullable: false),
                    EmailMadre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailPT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoNut = table.Column<int>(type: "int", nullable: false),
                    FNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LacMaterna = table.Column<int>(type: "int", nullable: false),
                    Localidad = table.Column<int>(type: "int", nullable: false),
                    NomApMadre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomApPadre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PApellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaisID = table.Column<int>(type: "int", nullable: false),
                    Pani = table.Column<int>(type: "int", nullable: false),
                    ReferenciaDir = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegNacimiento = table.Column<bool>(type: "bit", nullable: false),
                    SApellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SegMedico = table.Column<int>(type: "int", nullable: false),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    TComIndigena = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TSeguro = table.Column<int>(type: "int", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Captacion", x => x.CaptacionID);
                    table.ForeignKey(
                        name: "FK_Captacion_Departamento_DepartamentoID",
                        column: x => x.DepartamentoID,
                        principalTable: "Departamento",
                        principalColumn: "DepartamentoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Captacion_Distrito_DistritoID",
                        column: x => x.DistritoID,
                        principalTable: "Distrito",
                        principalColumn: "DistritoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Captacion_Pais_PaisID",
                        column: x => x.PaisID,
                        principalTable: "Pais",
                        principalColumn: "PaisID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Captacion_DepartamentoID",
                table: "Captacion",
                column: "DepartamentoID");

            migrationBuilder.CreateIndex(
                name: "IX_Captacion_DistritoID",
                table: "Captacion",
                column: "DistritoID");

            migrationBuilder.CreateIndex(
                name: "IX_Captacion_PaisID",
                table: "Captacion",
                column: "PaisID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Captacion");

            migrationBuilder.AlterColumn<string>(
                name: "NBiologico",
                table: "Biologico",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);
        }
    }
}
