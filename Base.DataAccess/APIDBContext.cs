using Base.Entity.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseAPI.DataAccess
{
    public partial class APIDBContext : DbContext
    {
        public APIDBContext(DbContextOptions<APIDBContext> options) : base(options)
        {

        }

        public virtual DbSet<Bodega> Bodegas { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<GuiaProducto> GuiaProductos { get; set; } = null!;
        public virtual DbSet<Guium> Guia { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Respuestum> Respuesta { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<TipoGuium> TipoGuia { get; set; } = null!;
        public virtual DbSet<TipoProducto> TipoProductos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<UsuarioxRole> UsuarioxRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bodega>(entity =>
            {
                entity.ToTable("Bodega");

                entity.Property(e => e.DescripcionBodega).HasMaxLength(50);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.Apellido).HasMaxLength(50);

                entity.Property(e => e.Cedula).HasMaxLength(20);

                entity.Property(e => e.Direccion).HasMaxLength(30);

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.Telefono).HasMaxLength(20);
            });

            modelBuilder.Entity<GuiaProducto>(entity =>
            {
                entity.ToTable("Guia_Producto");

                entity.Property(e => e.DescripcionGuiaProducto).HasMaxLength(250);

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.PrecioEnvio).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Guia)
                    .WithMany(p => p.GuiaProductos)
                    .HasForeignKey(d => d.GuiaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Guia_Producto_Guia");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.GuiaProductos)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Guia_Producto_Producto");
            });

            modelBuilder.Entity<Guium>(entity =>
            {
                entity.HasKey(e => e.GuiaId);

                entity.Property(e => e.Consecutivo).HasMaxLength(10);

                entity.Property(e => e.FechaEntrega).HasColumnType("datetime");

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.NumeroGuia)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(N'newid()')");

                entity.HasOne(d => d.Bodega)
                    .WithMany(p => p.Guia)
                    .HasForeignKey(d => d.BodegaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Guia_Bodega");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Guia)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Guia_Cliente");

                entity.HasOne(d => d.TipoGuia)
                    .WithMany(p => p.Guia)
                    .HasForeignKey(d => d.TipoGuiaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Guia_TipoGuia");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("Persona");

                entity.Property(e => e.Apellido).HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono).HasMaxLength(50);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto");

                entity.Property(e => e.DescripcionProducto).HasMaxLength(50);

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.TipoProducto)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.TipoProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_TipoProducto");
            });

            modelBuilder.Entity<Respuestum>(entity =>
            {
                entity.HasKey(e => e.IdRespuesta);

                entity.ToTable("Respuestum");

                entity.Property(e => e.IdRespuesta).ValueGeneratedNever();

                entity.Property(e => e.MensajeRespuesta).HasMaxLength(100);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RolId);

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<TipoGuium>(entity =>
            {
                entity.HasKey(e => e.TipoGuiaId);

                entity.Property(e => e.DescripcionTipoGuia).HasMaxLength(50);
            });

            modelBuilder.Entity<TipoProducto>(entity =>
            {
                entity.ToTable("TipoProducto");

                entity.Property(e => e.DescripcionTipoProducto).HasMaxLength(50);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.PersonaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_Persona");
            });

            modelBuilder.Entity<UsuarioxRole>(entity =>
            {
                entity.HasKey(e => e.UsuarioIdxRolesId);

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.UsuarioxRoles)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuarioxRoles_Roles");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.UsuarioxRoles)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuarioxRoles_Usuarios");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}