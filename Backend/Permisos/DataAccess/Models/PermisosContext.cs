using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataAccess.Models
{
    public partial class PermisosContext : DbContext
    {
        public PermisosContext()
        {
        }

        public PermisosContext(DbContextOptions<PermisosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Permiso> Permisos { get; set; }
        public virtual DbSet<TipoPermiso> TipoPermisos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-70SA4GV\\RAYMER; initial catalog=test;Integrated security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.ToTable("Permiso");

                entity.Property(e => e.ApellidoEmpleado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Apellido_Empleado");

                entity.Property(e => e.FechaPermiso)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Permiso");

                entity.Property(e => e.NombreEmpleado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_Empleado");

                entity.Property(e => e.TipoPermiso).HasColumnName("Tipo_Permiso");

                entity.HasOne(d => d.TipoPermisoNavigation)
                    .WithMany(p => p.Permisos)
                    .HasForeignKey(d => d.TipoPermiso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Permiso_TipoPermiso");
            });

            modelBuilder.Entity<TipoPermiso>(entity =>
            {
                entity.ToTable("TipoPermiso");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
