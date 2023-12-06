using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ZapateriaTBD.Models;

public partial class ZapateriaContext : DbContext
{
    public ZapateriaContext()
    {
    }

    public ZapateriaContext(DbContextOptions<ZapateriaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorias> Categorias { get; set; }

    public virtual DbSet<Zapatos> Zapatos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=Zapateria", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.35-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Categorias>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("categorias");

            entity.Property(e => e.Nombre).HasMaxLength(45);
        });

        modelBuilder.Entity<Zapatos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("zapatos");

            entity.HasIndex(e => e.IdCategorias, "fkCategoriasZapatos_idx");

            entity.Property(e => e.Color).HasMaxLength(20);
            entity.Property(e => e.Descripcion).HasMaxLength(100);
            entity.Property(e => e.Marca).HasMaxLength(50);
            entity.Property(e => e.Precio).HasPrecision(10);

            entity.HasOne(d => d.IdCategoriasNavigation).WithMany(p => p.Zapatos)
                .HasForeignKey(d => d.IdCategorias)
                .HasConstraintName("fkCategoriasZapatos");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
