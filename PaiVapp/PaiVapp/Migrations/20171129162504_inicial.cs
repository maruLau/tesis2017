using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PaiVapp.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Biologico",
                columns: table => new
                {
                    BiologicoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    NBiologico = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biologico", x => x.BiologicoID);
                });

            migrationBuilder.CreateTable(
                name: "CategoriaServicio",
                columns: table => new
                {
                    CategoriaServicioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    NCategoria = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaServicio", x => x.CategoriaServicioID);
                });

            migrationBuilder.CreateTable(
                name: "Dosis",
                columns: table => new
                {
                    DosisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    NDosis = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dosis", x => x.DosisID);
                });

            migrationBuilder.CreateTable(
                name: "Edad",
                columns: table => new
                {
                    EdadID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    NEdad = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Semanas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edad", x => x.EdadID);
                });

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    PaisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    NPais = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.PaisID);
                });

            migrationBuilder.CreateTable(
                name: "DosisBiologico",
                columns: table => new
                {
                    DosisBiologicoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BiologicoID = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DosisID = table.Column<int>(type: "int", nullable: false),
                    EdadID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DosisBiologico", x => x.DosisBiologicoID);
                    table.ForeignKey(
                        name: "FK_DosisBiologico_Biologico_BiologicoID",
                        column: x => x.BiologicoID,
                        principalTable: "Biologico",
                        principalColumn: "BiologicoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DosisBiologico_Dosis_DosisID",
                        column: x => x.DosisID,
                        principalTable: "Dosis",
                        principalColumn: "DosisID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DosisBiologico_Edad_EdadID",
                        column: x => x.EdadID,
                        principalTable: "Edad",
                        principalColumn: "EdadID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    DepartamentoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodDepartamento = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    NDepartamento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PaisID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.DepartamentoID);
                    table.ForeignKey(
                        name: "FK_Departamento_Pais_PaisID",
                        column: x => x.PaisID,
                        principalTable: "Pais",
                        principalColumn: "PaisID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Distrito",
                columns: table => new
                {
                    DistritoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodDistrito = table.Column<int>(type: "int", nullable: false),
                    DepartamentoID = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    NDistrito = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distrito", x => x.DistritoID);
                    table.ForeignKey(
                        name: "FK_Distrito_Departamento_DepartamentoID",
                        column: x => x.DepartamentoID,
                        principalTable: "Departamento",
                        principalColumn: "DepartamentoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegionSanitaria",
                columns: table => new
                {
                    RegionSanitariaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodRS = table.Column<int>(type: "int", nullable: false),
                    DepartamentoID = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    NRegionS = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionSanitaria", x => x.RegionSanitariaID);
                    table.ForeignKey(
                        name: "FK_RegionSanitaria_Departamento_DepartamentoID",
                        column: x => x.DepartamentoID,
                        principalTable: "Departamento",
                        principalColumn: "DepartamentoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Servicio",
                columns: table => new
                {
                    ServicioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cabecera = table.Column<bool>(type: "bit", nullable: false),
                    CategoriaServicioID = table.Column<int>(type: "int", nullable: false),
                    CodServicio = table.Column<int>(type: "int", nullable: false),
                    DistanciaRS = table.Column<int>(type: "int", nullable: false),
                    DistritoID = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    NServicio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PoblacionMenor = table.Column<int>(type: "int", nullable: false),
                    RegionSanitariaID = table.Column<int>(type: "int", nullable: false),
                    TipoServicio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicio", x => x.ServicioID);
                    table.ForeignKey(
                        name: "FK_Servicio_CategoriaServicio_CategoriaServicioID",
                        column: x => x.CategoriaServicioID,
                        principalTable: "CategoriaServicio",
                        principalColumn: "CategoriaServicioID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Servicio_Distrito_DistritoID",
                        column: x => x.DistritoID,
                        principalTable: "Distrito",
                        principalColumn: "DistritoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Servicio_RegionSanitaria_RegionSanitariaID",
                        column: x => x.RegionSanitariaID,
                        principalTable: "RegionSanitaria",
                        principalColumn: "RegionSanitariaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_PaisID",
                table: "Departamento",
                column: "PaisID");

            migrationBuilder.CreateIndex(
                name: "IX_Distrito_DepartamentoID",
                table: "Distrito",
                column: "DepartamentoID");

            migrationBuilder.CreateIndex(
                name: "IX_DosisBiologico_BiologicoID",
                table: "DosisBiologico",
                column: "BiologicoID");

            migrationBuilder.CreateIndex(
                name: "IX_DosisBiologico_DosisID",
                table: "DosisBiologico",
                column: "DosisID");

            migrationBuilder.CreateIndex(
                name: "IX_DosisBiologico_EdadID",
                table: "DosisBiologico",
                column: "EdadID");

            migrationBuilder.CreateIndex(
                name: "IX_RegionSanitaria_DepartamentoID",
                table: "RegionSanitaria",
                column: "DepartamentoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Servicio_CategoriaServicioID",
                table: "Servicio",
                column: "CategoriaServicioID");

            migrationBuilder.CreateIndex(
                name: "IX_Servicio_DistritoID",
                table: "Servicio",
                column: "DistritoID");

            migrationBuilder.CreateIndex(
                name: "IX_Servicio_RegionSanitariaID",
                table: "Servicio",
                column: "RegionSanitariaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DosisBiologico");

            migrationBuilder.DropTable(
                name: "Servicio");

            migrationBuilder.DropTable(
                name: "Biologico");

            migrationBuilder.DropTable(
                name: "Dosis");

            migrationBuilder.DropTable(
                name: "Edad");

            migrationBuilder.DropTable(
                name: "CategoriaServicio");

            migrationBuilder.DropTable(
                name: "Distrito");

            migrationBuilder.DropTable(
                name: "RegionSanitaria");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropTable(
                name: "Pais");
        }
    }
}
