﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using PaiVapp.Data;
using System;

namespace PaiVapp.Migrations
{
    [DbContext(typeof(PaiVContext))]
    [Migration("20171030235554_ModelosInicial")]
    partial class ModelosInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PaiVapp.Models.Biologico", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion")
                        .HasMaxLength(50);

                    b.Property<bool>("Estado");

                    b.Property<string>("NBiologico")
                        .HasMaxLength(20);

                    b.HasKey("ID");

                    b.ToTable("Biologico");
                });

            modelBuilder.Entity("PaiVapp.Models.CategoriaServicio", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion")
                        .HasMaxLength(40);

                    b.Property<bool>("Estado");

                    b.Property<string>("NCategoria")
                        .HasMaxLength(15);

                    b.Property<int?>("ServicioID");

                    b.HasKey("ID");

                    b.HasIndex("ServicioID");

                    b.ToTable("CategoriaServicio");
                });

            modelBuilder.Entity("PaiVapp.Models.Departamento", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CodDepartamento");

                    b.Property<bool>("Estado");

                    b.Property<string>("NDepartamento")
                        .HasMaxLength(50);

                    b.Property<int?>("PaisID");

                    b.HasKey("ID");

                    b.HasIndex("PaisID");

                    b.ToTable("Departamento");
                });

            modelBuilder.Entity("PaiVapp.Models.Distrito", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CodDistrito");

                    b.Property<int?>("DepartamentoID");

                    b.Property<bool>("Estado");

                    b.Property<string>("NDistrito")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.HasIndex("DepartamentoID");

                    b.ToTable("Distrito");
                });

            modelBuilder.Entity("PaiVapp.Models.Dosis", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Estado");

                    b.Property<string>("NDosis")
                        .HasMaxLength(15);

                    b.HasKey("ID");

                    b.ToTable("Dosis");
                });

            modelBuilder.Entity("PaiVapp.Models.DosisBiologico", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BiologicoID");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(50);

                    b.Property<int>("DosisID");

                    b.Property<int>("EdadID");

                    b.HasKey("ID");

                    b.HasIndex("BiologicoID");

                    b.HasIndex("DosisID");

                    b.HasIndex("EdadID");

                    b.ToTable("DosisBiologico");
                });

            modelBuilder.Entity("PaiVapp.Models.Edad", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Estado");

                    b.Property<string>("NEdad")
                        .HasMaxLength(15);

                    b.Property<int>("Semanas");

                    b.HasKey("ID");

                    b.ToTable("Edad");
                });

            modelBuilder.Entity("PaiVapp.Models.Pais", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Estado");

                    b.Property<string>("NPais")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Pais");
                });

            modelBuilder.Entity("PaiVapp.Models.RegionSanitaria", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CodRS");

                    b.Property<int?>("DepartamentoID");

                    b.Property<bool>("Estado");

                    b.Property<string>("NRegionS")
                        .HasMaxLength(20);

                    b.HasKey("ID");

                    b.HasIndex("DepartamentoID");

                    b.ToTable("RegionSanitaria");
                });

            modelBuilder.Entity("PaiVapp.Models.Servicio", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Cabecera");

                    b.Property<int>("CodServicio");

                    b.Property<int>("DistanciaRS");

                    b.Property<int?>("DistritoID");

                    b.Property<string>("NServicio")
                        .HasMaxLength(50);

                    b.Property<int>("PoblacionMenor");

                    b.Property<int?>("RegSanitariaID");

                    b.Property<int>("TipoServicio");

                    b.HasKey("ID");

                    b.HasIndex("DistritoID");

                    b.HasIndex("RegSanitariaID");

                    b.ToTable("Servicio");
                });

            modelBuilder.Entity("PaiVapp.Models.CategoriaServicio", b =>
                {
                    b.HasOne("PaiVapp.Models.Servicio", "Servicio")
                        .WithMany("CatServicio")
                        .HasForeignKey("ServicioID");
                });

            modelBuilder.Entity("PaiVapp.Models.Departamento", b =>
                {
                    b.HasOne("PaiVapp.Models.Pais", "Pais")
                        .WithMany("Departamento")
                        .HasForeignKey("PaisID");
                });

            modelBuilder.Entity("PaiVapp.Models.Distrito", b =>
                {
                    b.HasOne("PaiVapp.Models.Departamento", "Departamento")
                        .WithMany("Distrito")
                        .HasForeignKey("DepartamentoID");
                });

            modelBuilder.Entity("PaiVapp.Models.DosisBiologico", b =>
                {
                    b.HasOne("PaiVapp.Models.Biologico", "Biologico")
                        .WithMany("DosisBiologico")
                        .HasForeignKey("BiologicoID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PaiVapp.Models.Dosis", "Dosis")
                        .WithMany("DosisBiologico")
                        .HasForeignKey("DosisID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PaiVapp.Models.Edad", "Edad")
                        .WithMany("DosisBiologico")
                        .HasForeignKey("EdadID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PaiVapp.Models.RegionSanitaria", b =>
                {
                    b.HasOne("PaiVapp.Models.Departamento", "Departamento")
                        .WithMany()
                        .HasForeignKey("DepartamentoID");
                });

            modelBuilder.Entity("PaiVapp.Models.Servicio", b =>
                {
                    b.HasOne("PaiVapp.Models.Distrito", "Distrito")
                        .WithMany()
                        .HasForeignKey("DistritoID");

                    b.HasOne("PaiVapp.Models.RegionSanitaria", "RegSanitaria")
                        .WithMany("Servicio")
                        .HasForeignKey("RegSanitariaID");
                });
#pragma warning restore 612, 618
        }
    }
}
