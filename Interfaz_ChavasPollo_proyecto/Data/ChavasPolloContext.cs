using System;
using System.Collections.Generic;
using Interfaz_ChavasPollo_proyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace Interfaz_ChavasPollo_proyecto.Data;

public partial class ChavasPolloContext : DbContext
{
    public ChavasPolloContext(DbContextOptions<ChavasPolloContext> options)
        : base(options)
    {
    }

    public virtual DbSet<categoria> categorias { get; set; }

    public virtual DbSet<detalleordene> detalleordenes { get; set; }

    public virtual DbSet<empleado> empleados { get; set; }

    public virtual DbSet<facturacion> facturacions { get; set; }

    public virtual DbSet<inventario> inventarios { get; set; }

    public virtual DbSet<menu> menus { get; set; }

    public virtual DbSet<ordene> ordenes { get; set; }

    public virtual DbSet<proveedore> proveedores { get; set; }

    public virtual DbSet<role> roles { get; set; }

    public virtual DbSet<turno> turnos { get; set; }

    public virtual DbSet<unidad_medidum> unidad_medida { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<categoria>(entity =>
        {
            entity.HasKey(e => e.id_categoria).HasName("PK__categori__CD54BC5AC486923C");

            entity.Property(e => e.id_categoria).ValueGeneratedNever();
            entity.Property(e => e.nombre_cat)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<detalleordene>(entity =>
        {
            entity.HasKey(e => e.id_detalle).HasName("PK__detalleo__4F1332DE2AAAAB9B");

            entity.Property(e => e.id_detalle).ValueGeneratedNever();

            entity.HasOne(d => d.id_menuNavigation).WithMany(p => p.detalleordenes)
                .HasForeignKey(d => d.id_menu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_detalleXmenu");

            entity.HasOne(d => d.id_ordenNavigation).WithMany(p => p.detalleordenes)
                .HasForeignKey(d => d.id_orden)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_detalleXorden");
        });

        modelBuilder.Entity<empleado>(entity =>
        {
            entity.HasKey(e => e.id_empleado).HasName("PK__empleado__88B51394472712A8");

            entity.Property(e => e.id_empleado).ValueGeneratedNever();
            entity.Property(e => e.nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.telefono)
                .HasMaxLength(8)
                .IsUnicode(false);

            entity.HasOne(d => d.id_rolNavigation).WithMany(p => p.empleados)
                .HasForeignKey(d => d.id_rol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_empXrol");

            entity.HasOne(d => d.id_turnosNavigation).WithMany(p => p.empleados)
                .HasForeignKey(d => d.id_turnos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_empXturno");
        });

        modelBuilder.Entity<facturacion>(entity =>
        {
            entity.HasKey(e => e.id_factura).HasName("PK__facturac__6C08ED53BB32D094");

            entity.ToTable("facturacion");

            entity.Property(e => e.id_factura).ValueGeneratedNever();
            entity.Property(e => e.fecha_factura)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.total).HasColumnType("decimal(8, 2)");

            entity.HasOne(d => d.id_ordenNavigation).WithMany(p => p.facturacions)
                .HasForeignKey(d => d.id_orden)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_factXordenes");
        });

        modelBuilder.Entity<inventario>(entity =>
        {
            entity.HasKey(e => e.id_inv).HasName("PK__inventar__D62AAC337D217ABA");

            entity.ToTable("inventario");

            entity.Property(e => e.id_inv).ValueGeneratedNever();
            entity.Property(e => e.nombre_prod)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.id_proveedorNavigation).WithMany(p => p.inventarios)
                .HasForeignKey(d => d.id_proveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_invXprov");

            entity.HasOne(d => d.id_unidadNavigation).WithMany(p => p.inventarios)
                .HasForeignKey(d => d.id_unidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_invXunid");
        });

        modelBuilder.Entity<menu>(entity =>
        {
            entity.HasKey(e => e.id_menu).HasName("PK__menu__68A1D9DBE067BECE");

            entity.ToTable("menu");

            entity.Property(e => e.id_menu).ValueGeneratedNever();
            entity.Property(e => e.nombre_platillo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.precio).HasColumnType("decimal(8, 2)");

            entity.HasOne(d => d.id_categoriaNavigation).WithMany(p => p.menus)
                .HasForeignKey(d => d.id_categoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_menuXcat");
        });

        modelBuilder.Entity<ordene>(entity =>
        {
            entity.HasKey(e => e.id_orden).HasName("PK__ordenes__DD5B8F33AB5A72BA");

            entity.Property(e => e.fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.id_empleadoNavigation).WithMany(p => p.ordenes)
                .HasForeignKey(d => d.id_empleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ordenXemp");
        });

        modelBuilder.Entity<proveedore>(entity =>
        {
            entity.HasKey(e => e.id_proveedor).HasName("PK__proveedo__8D3DFE280E9E9681");

            entity.Property(e => e.id_proveedor).ValueGeneratedNever();
            entity.Property(e => e.nombre_prov)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<role>(entity =>
        {
            entity.HasKey(e => e.id_rol).HasName("PK__roles__6ABCB5E01E9F739E");

            entity.Property(e => e.id_rol).ValueGeneratedNever();
            entity.Property(e => e.nombre_rol)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<turno>(entity =>
        {
            entity.HasKey(e => e.id_turnos).HasName("PK__turnos__B180B38FACEDF783");

            entity.Property(e => e.id_turnos).ValueGeneratedNever();
            entity.Property(e => e.nombre_turno)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<unidad_medidum>(entity =>
        {
            entity.HasKey(e => e.id_unidad).HasName("PK__unidad_m__95D7C92B658AA113");

            entity.Property(e => e.id_unidad).ValueGeneratedNever();
            entity.Property(e => e.nombrre_unidad)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
