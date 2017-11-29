using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaiVapp.Models;
namespace PaiVapp.Data
{
    public class PaiVContext : DbContext
    {
        public PaiVContext()
        {
        }

        public PaiVContext(DbContextOptions<PaiVContext> options) : base(options){}

        public DbSet<Pais> Paises { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Distrito> Distritos { get; set; }
        public DbSet<RegionSanitaria> RegionSanitarias { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<CategoriaServicio> CategoriaServicios { get; set; }
        public DbSet<Edad> Edades { get; set; }
        public DbSet<Biologico> Biologicos { get; set; }
        public DbSet<Dosis> Dosis { get; set; }
        public DbSet<DosisBiologico> DosisBiologicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pais>().ToTable("Pais");
            modelBuilder.Entity<Departamento>().ToTable("Departamento");
            modelBuilder.Entity<Distrito>().ToTable("Distrito");
            modelBuilder.Entity<RegionSanitaria>().ToTable("RegionSanitaria");
// modelBuilder.Entity<Servicio>().ToTable("Servicio");
            modelBuilder.Entity<Servicio>().ToTable("Servicio")
                .HasOne(p => p.RegionSanitaria)
                .WithMany(b => b.Servicios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .IsRequired();
            modelBuilder.Entity<CategoriaServicio>().ToTable("CategoriaServicio");
            modelBuilder.Entity<Edad>().ToTable("Edad");
            modelBuilder.Entity<Biologico>().ToTable("Biologico");
            modelBuilder.Entity<Dosis>().ToTable("Dosis");
            modelBuilder.Entity<DosisBiologico>().ToTable("DosisBiologico");

        }
        
    }
}
