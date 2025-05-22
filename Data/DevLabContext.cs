using System;
using System.Collections.Generic;
using FacturaWilmer.Entities;
using Microsoft.EntityFrameworkCore;

namespace FacturaWilmer.Data;

public partial class DevLabContext : DbContext
{
    public DevLabContext()
    {
    }

    public DevLabContext(DbContextOptions<DevLabContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CatProducto> CatProductos { get; set; }

    public virtual DbSet<CatTipoCliente> CatTipoClientes { get; set; }

    public virtual DbSet<TblCliente> TblClientes { get; set; }

    public virtual DbSet<TblDetallesFactura> TblDetallesFacturas { get; set; }

    public virtual DbSet<TblFactura> TblFacturas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-40R7NEB;Database=DevLab;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CatProducto>(entity =>
        {
            entity.Property(e => e.Ext)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ext");
            entity.Property(e => e.ImagenProducto).HasColumnType("image");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<CatTipoCliente>(entity =>
        {
            entity.ToTable("CatTipoCliente");

            entity.Property(e => e.TipoCliente)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblCliente>(entity =>
        {
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Rfc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RFC");

            entity.HasOne(d => d.IdTipoClienteNavigation).WithMany(p => p.TblClientes)
                .HasForeignKey(d => d.IdTipoCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblClientes_CatTipoCliente");
        });

        modelBuilder.Entity<TblDetallesFactura>(entity =>
        {
            entity.ToTable("TblDetallesFactura");

            entity.Property(e => e.Notas)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PrecioUnitarioProducto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SubtotalProducto).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdFacturaNavigation).WithMany(p => p.TblDetallesFacturas)
                .HasForeignKey(d => d.IdFactura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblDetallesFactura_TblFacturas");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.TblDetallesFacturas)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblDetallesFactura_CatProductos");
        });

        modelBuilder.Entity<TblFactura>(entity =>
        {
            entity.Property(e => e.FechaEmisionFactura).HasColumnType("datetime");
            entity.Property(e => e.SubTotalFacturas).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalFactura).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalImpuestos).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.TblFacturas)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblFacturas_TblClientes");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
