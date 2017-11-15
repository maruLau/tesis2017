using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PaiVapp.Migrations
{
    public partial class CorrecModelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaServicio_Servicio_ServicioID",
                table: "CategoriaServicio");

            migrationBuilder.DropForeignKey(
                name: "FK_Departamento_Pais_PaisID",
                table: "Departamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Distrito_Departamento_DepartamentoID",
                table: "Distrito");

            migrationBuilder.DropForeignKey(
                name: "FK_DosisBiologico_Biologico_BiologicoID",
                table: "DosisBiologico");

            migrationBuilder.DropForeignKey(
                name: "FK_DosisBiologico_Dosis_DosisID",
                table: "DosisBiologico");

            migrationBuilder.DropForeignKey(
                name: "FK_DosisBiologico_Edad_EdadID",
                table: "DosisBiologico");

            migrationBuilder.DropForeignKey(
                name: "FK_RegionSanitaria_Departamento_DepartamentoID",
                table: "RegionSanitaria");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicio_Distrito_DistritoID",
                table: "Servicio");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicio_RegionSanitaria_RegSanitariaID",
                table: "Servicio");

            migrationBuilder.DropIndex(
                name: "IX_Servicio_RegSanitariaID",
                table: "Servicio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegionSanitaria",
                table: "RegionSanitaria");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pais",
                table: "Pais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Edad",
                table: "Edad");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DosisBiologico",
                table: "DosisBiologico");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dosis",
                table: "Dosis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Distrito",
                table: "Distrito");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departamento",
                table: "Departamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoriaServicio",
                table: "CategoriaServicio");

            migrationBuilder.DropIndex(
                name: "IX_CategoriaServicio_ServicioID",
                table: "CategoriaServicio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Biologico",
                table: "Biologico");

            migrationBuilder.DropColumn(
                name: "RegSanitariaID",
                table: "Servicio");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "RegionSanitaria");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Pais");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Edad");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "DosisBiologico");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Dosis");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Distrito");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "CategoriaServicio");

            migrationBuilder.DropColumn(
                name: "ServicioID",
                table: "CategoriaServicio");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Biologico");

            migrationBuilder.AlterColumn<int>(
                name: "DistritoID",
                table: "Servicio",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CatServicioID",
                table: "Servicio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoriaServicioID",
                table: "Servicio",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegionSanitariaID",
                table: "Servicio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegionSanitariaID",
                table: "RegionSanitaria",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentoID",
                table: "RegionSanitaria",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaisID",
                table: "Pais",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "EdadID",
                table: "Edad",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "DosisBiologicoID",
                table: "DosisBiologico",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "DosisID",
                table: "Dosis",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoID",
                table: "Distrito",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistritoID",
                table: "Distrito",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "PaisID",
                table: "Departamento",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoID",
                table: "Departamento",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "CategoriaServicioID",
                table: "CategoriaServicio",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "BiologicoID",
                table: "Biologico",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegionSanitaria",
                table: "RegionSanitaria",
                column: "RegionSanitariaID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pais",
                table: "Pais",
                column: "PaisID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Edad",
                table: "Edad",
                column: "EdadID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DosisBiologico",
                table: "DosisBiologico",
                column: "DosisBiologicoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dosis",
                table: "Dosis",
                column: "DosisID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Distrito",
                table: "Distrito",
                column: "DistritoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departamento",
                table: "Departamento",
                column: "DepartamentoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoriaServicio",
                table: "CategoriaServicio",
                column: "CategoriaServicioID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Biologico",
                table: "Biologico",
                column: "BiologicoID");

            migrationBuilder.CreateIndex(
                name: "IX_Servicio_CategoriaServicioID",
                table: "Servicio",
                column: "CategoriaServicioID");

            migrationBuilder.CreateIndex(
                name: "IX_Servicio_RegionSanitariaID",
                table: "Servicio",
                column: "RegionSanitariaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Departamento_Pais_PaisID",
                table: "Departamento",
                column: "PaisID",
                principalTable: "Pais",
                principalColumn: "PaisID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Distrito_Departamento_DepartamentoID",
                table: "Distrito",
                column: "DepartamentoID",
                principalTable: "Departamento",
                principalColumn: "DepartamentoID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DosisBiologico_Biologico_BiologicoID",
                table: "DosisBiologico",
                column: "BiologicoID",
                principalTable: "Biologico",
                principalColumn: "BiologicoID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DosisBiologico_Dosis_DosisID",
                table: "DosisBiologico",
                column: "DosisID",
                principalTable: "Dosis",
                principalColumn: "DosisID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DosisBiologico_Edad_EdadID",
                table: "DosisBiologico",
                column: "EdadID",
                principalTable: "Edad",
                principalColumn: "EdadID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegionSanitaria_Departamento_DepartamentoID",
                table: "RegionSanitaria",
                column: "DepartamentoID",
                principalTable: "Departamento",
                principalColumn: "DepartamentoID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicio_CategoriaServicio_CategoriaServicioID",
                table: "Servicio",
                column: "CategoriaServicioID",
                principalTable: "CategoriaServicio",
                principalColumn: "CategoriaServicioID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicio_Distrito_DistritoID",
                table: "Servicio",
                column: "DistritoID",
                principalTable: "Distrito",
                principalColumn: "DistritoID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicio_RegionSanitaria_RegionSanitariaID",
                table: "Servicio",
                column: "RegionSanitariaID",
                principalTable: "RegionSanitaria",
                principalColumn: "RegionSanitariaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departamento_Pais_PaisID",
                table: "Departamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Distrito_Departamento_DepartamentoID",
                table: "Distrito");

            migrationBuilder.DropForeignKey(
                name: "FK_DosisBiologico_Biologico_BiologicoID",
                table: "DosisBiologico");

            migrationBuilder.DropForeignKey(
                name: "FK_DosisBiologico_Dosis_DosisID",
                table: "DosisBiologico");

            migrationBuilder.DropForeignKey(
                name: "FK_DosisBiologico_Edad_EdadID",
                table: "DosisBiologico");

            migrationBuilder.DropForeignKey(
                name: "FK_RegionSanitaria_Departamento_DepartamentoID",
                table: "RegionSanitaria");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicio_CategoriaServicio_CategoriaServicioID",
                table: "Servicio");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicio_Distrito_DistritoID",
                table: "Servicio");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicio_RegionSanitaria_RegionSanitariaID",
                table: "Servicio");

            migrationBuilder.DropIndex(
                name: "IX_Servicio_CategoriaServicioID",
                table: "Servicio");

            migrationBuilder.DropIndex(
                name: "IX_Servicio_RegionSanitariaID",
                table: "Servicio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegionSanitaria",
                table: "RegionSanitaria");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pais",
                table: "Pais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Edad",
                table: "Edad");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DosisBiologico",
                table: "DosisBiologico");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dosis",
                table: "Dosis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Distrito",
                table: "Distrito");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departamento",
                table: "Departamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoriaServicio",
                table: "CategoriaServicio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Biologico",
                table: "Biologico");

            migrationBuilder.DropColumn(
                name: "CatServicioID",
                table: "Servicio");

            migrationBuilder.DropColumn(
                name: "CategoriaServicioID",
                table: "Servicio");

            migrationBuilder.DropColumn(
                name: "RegionSanitariaID",
                table: "Servicio");

            migrationBuilder.DropColumn(
                name: "RegionSanitariaID",
                table: "RegionSanitaria");

            migrationBuilder.DropColumn(
                name: "DepartmentoID",
                table: "RegionSanitaria");

            migrationBuilder.DropColumn(
                name: "PaisID",
                table: "Pais");

            migrationBuilder.DropColumn(
                name: "EdadID",
                table: "Edad");

            migrationBuilder.DropColumn(
                name: "DosisBiologicoID",
                table: "DosisBiologico");

            migrationBuilder.DropColumn(
                name: "DosisID",
                table: "Dosis");

            migrationBuilder.DropColumn(
                name: "DistritoID",
                table: "Distrito");

            migrationBuilder.DropColumn(
                name: "DepartamentoID",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "CategoriaServicioID",
                table: "CategoriaServicio");

            migrationBuilder.DropColumn(
                name: "BiologicoID",
                table: "Biologico");

            migrationBuilder.AlterColumn<int>(
                name: "DistritoID",
                table: "Servicio",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RegSanitariaID",
                table: "Servicio",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "RegionSanitaria",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Pais",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Edad",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "DosisBiologico",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Dosis",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoID",
                table: "Distrito",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Distrito",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "PaisID",
                table: "Departamento",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Departamento",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "CategoriaServicio",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "ServicioID",
                table: "CategoriaServicio",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Biologico",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegionSanitaria",
                table: "RegionSanitaria",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pais",
                table: "Pais",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Edad",
                table: "Edad",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DosisBiologico",
                table: "DosisBiologico",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dosis",
                table: "Dosis",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Distrito",
                table: "Distrito",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departamento",
                table: "Departamento",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoriaServicio",
                table: "CategoriaServicio",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Biologico",
                table: "Biologico",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Servicio_RegSanitariaID",
                table: "Servicio",
                column: "RegSanitariaID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaServicio_ServicioID",
                table: "CategoriaServicio",
                column: "ServicioID");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaServicio_Servicio_ServicioID",
                table: "CategoriaServicio",
                column: "ServicioID",
                principalTable: "Servicio",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departamento_Pais_PaisID",
                table: "Departamento",
                column: "PaisID",
                principalTable: "Pais",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Distrito_Departamento_DepartamentoID",
                table: "Distrito",
                column: "DepartamentoID",
                principalTable: "Departamento",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DosisBiologico_Biologico_BiologicoID",
                table: "DosisBiologico",
                column: "BiologicoID",
                principalTable: "Biologico",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DosisBiologico_Dosis_DosisID",
                table: "DosisBiologico",
                column: "DosisID",
                principalTable: "Dosis",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DosisBiologico_Edad_EdadID",
                table: "DosisBiologico",
                column: "EdadID",
                principalTable: "Edad",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegionSanitaria_Departamento_DepartamentoID",
                table: "RegionSanitaria",
                column: "DepartamentoID",
                principalTable: "Departamento",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicio_Distrito_DistritoID",
                table: "Servicio",
                column: "DistritoID",
                principalTable: "Distrito",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicio_RegionSanitaria_RegSanitariaID",
                table: "Servicio",
                column: "RegSanitariaID",
                principalTable: "RegionSanitaria",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
