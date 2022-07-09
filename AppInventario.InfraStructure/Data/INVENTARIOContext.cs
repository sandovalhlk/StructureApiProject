using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AppInventario.InfraStructure.Data
{
    public partial class INVENTARIOContext : DbContext
    {
        public INVENTARIOContext()
        {
        }

        public INVENTARIOContext(DbContextOptions<INVENTARIOContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<LineaProductos> LineaProductos { get; set; }
        public virtual DbSet<OrdenProductos> OrdenProductos { get; set; }
        public virtual DbSet<Ordenes> Ordenes { get; set; }
        public virtual DbSet<Pagos> Pagos { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("server=OMAR-PC\\SQLEXPRESS; database=DB_INVENTARIO; user id=sa; password=m0nimbo");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ClienteId");     

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LineaProductos>(entity =>
            {
                entity.HasKey(e => e.LineaProductoId);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrdenProductos>(entity =>
            {
                entity.HasKey(e => e.OrdenProductoId);

                entity.HasOne(d => d.Orden)
                    .WithMany(p => p.OrdenProductos)
                    .HasForeignKey(d => d.OrdenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdenProductos_Ordenes");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.OrdenProductos)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdenProductos_Productos");
            });

            modelBuilder.Entity<Ordenes>(entity =>
            {
                entity.HasKey(e => e.OrdenId);

                entity.Property(e => e.Comentarios)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.FechaOrden).HasColumnType("datetime");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Ordenes)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ordenes_Clientes");
            });

            modelBuilder.Entity<Pagos>(entity =>
            {
                entity.HasKey(e => e.PagoId);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.FechaPago).HasColumnType("datetime");

                entity.HasOne(d => d.Orden)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.OrdenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pagos_Ordenes");
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.HasKey(e => e.ProductoId);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.LineaProducto)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.LineaProductoId)
                    .HasConstraintName("FK_Productos_LineaProductos");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
