using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Intenteo6.Models.dbModels;
using Intenteo6.Models.DTO;

namespace Intenteo6.Models.dbModels;

public partial class DriveDreamDbContext : IdentityDbContext<AplicationUser,IdentityRole<int>,int>
{
    public DriveDreamDbContext()
    {
    }

    public DriveDreamDbContext(DbContextOptions<DriveDreamDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carro> Carros { get; set; }

    public virtual DbSet<Clasificacion> Clasificacions { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<FotosCar> FotosCars { get; set; }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<MetodoPago> MetodoPagos { get; set; }

    public virtual DbSet<Modelo> Modelos { get; set; }

    public virtual DbSet<Publicacion> Publicacions { get; set; }
  

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Carro>(entity =>
        {
            entity.HasOne(d => d.IdmodeloNavigation).WithMany(p => p.Carros)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Carro_modelo");

            entity.HasOne(d => d.MarcaNavigation).WithMany(p => p.Carros)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Carro_Marca");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasOne(d => d.IdCarNavigation).WithMany(p => p.Compras)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Compra_Carro");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Compras)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Compra_User");
        });

        modelBuilder.Entity<FotosCar>(entity =>
        {
            entity.Property(e => e.IdFoto).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdFotoNavigation).WithOne(p => p.FotosCar)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_fotosCar_Carro");
        });

        modelBuilder.Entity<MetodoPago>(entity =>
        {
            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.MetodoPagos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MetodoPago_User");
        });

        modelBuilder.Entity<Publicacion>(entity =>
        {
            entity.HasOne(d => d.ClasificacionNavigation).WithMany(p => p.Publicacions).HasConstraintName("FK_publicacion_Clasificacion");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Publicacions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_publicacion_User");
        });

       

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


}
