using System;
using System.Collections.Generic;
using Gestion_Empleados.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Empleados.Context;

public partial class GestionEmpleados3Context : DbContext
{
    public GestionEmpleados3Context()
    {
    }

    public GestionEmpleados3Context(DbContextOptions<GestionEmpleados3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Asistencium> Asistencia { get; set; }

    public virtual DbSet<Bitacora> Bitacoras { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<HistorialEmpleado> HistorialEmpleados { get; set; }

    public virtual DbSet<Justificacion> Justificacions { get; set; }

    public virtual DbSet<Sucursal> Sucursals { get; set; }

    public virtual DbSet<TipoEmpleado> TipoEmpleados { get; set; }

    public virtual DbSet<Turno> Turnos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Vacacione> Vacaciones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-GUBOL6B;Database=Gestion_Empleados3;Trust Server Certificate=true;User Id=Daniel;Password=pepon2025;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asistencium>(entity =>
        {
            entity.HasKey(e => e.IdAsistencia).HasName("PK__Asistenc__D0454A9AE9E6D3F4");

            entity.HasIndex(e => new { e.IdEmpleado, e.Fecha }, "uq_asistencia").IsUnique();

            entity.Property(e => e.IdAsistencia).HasColumnName("id_asistencia");
            entity.Property(e => e.CreadoPor).HasColumnName("creado_por");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.HoraEntrada).HasColumnName("hora_entrada");
            entity.Property(e => e.HoraSalida).HasColumnName("hora_salida");
            entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");
            entity.Property(e => e.Justificada)
                .HasDefaultValue(false)
                .HasColumnName("justificada");

            entity.HasOne(d => d.CreadoPorNavigation).WithMany(p => p.Asistencia)
                .HasForeignKey(d => d.CreadoPor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_asistencias_usuarios");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Asistencia)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_asistencias_empleados");
        });

        modelBuilder.Entity<Bitacora>(entity =>
        {
            entity.HasKey(e => e.IdLog).HasName("PK__Bitacora__6CC851FE1666BC7B");

            entity.ToTable("Bitacora");

            entity.Property(e => e.IdLog).HasColumnName("id_log");
            entity.Property(e => e.Accion)
                .HasMaxLength(255)
                .HasColumnName("accion");
            entity.Property(e => e.FechaHora)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_hora");
            entity.Property(e => e.TablaAfectada)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tabla_afectada");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Bitacoras)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_bitacora_usuarios");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PK__Departam__64F37A16C50FDA37");

            entity.ToTable("Departamento");

            entity.HasIndex(e => e.Nombre, "UQ__Departam__72AFBCC6E6698B48").IsUnique();

            entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__Empleado__88B51394048DFE25");

            entity.ToTable("Empleado");

            entity.HasIndex(e => e.Correo, "UQ__Empleado__2A586E0BAD1F9C50").IsUnique();

            entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.FechaIngreso).HasColumnName("fecha_ingreso");
            entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");
            entity.Property(e => e.IdSucursal).HasColumnName("id_sucursal");
            entity.Property(e => e.IdTipo).HasColumnName("id_tipo");
            entity.Property(e => e.IdTurno).HasColumnName("id_turno");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_empleados_departamento");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_empleados_sucursal");

            entity.HasOne(d => d.IdTipoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdTipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_empleados_tipoempleado");

            entity.HasOne(d => d.IdTurnoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdTurno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_empleados_turno");
        });

        modelBuilder.Entity<HistorialEmpleado>(entity =>
        {
            entity.HasKey(e => e.IdHistorial).HasName("PK__Historia__76E6C502EAA8792E");

            entity.ToTable("HistorialEmpleado");

            entity.Property(e => e.IdHistorial).HasColumnName("id_historial");
            entity.Property(e => e.CampoModificado)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("campo_modificado");
            entity.Property(e => e.FechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");
            entity.Property(e => e.ModificadoPor).HasColumnName("modificado_por");
            entity.Property(e => e.ValorAnterior).HasColumnName("valor_anterior");
            entity.Property(e => e.ValorNuevo).HasColumnName("valor_nuevo");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.HistorialEmpleados)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_historialempleado_empleados");

            entity.HasOne(d => d.ModificadoPorNavigation).WithMany(p => p.HistorialEmpleados)
                .HasForeignKey(d => d.ModificadoPor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_historialempleado_usuarios");
        });

        modelBuilder.Entity<Justificacion>(entity =>
        {
            entity.HasKey(e => e.IdJustificacion).HasName("PK__Justific__7FF39A98FB9F22DD");

            entity.ToTable("Justificacion");

            entity.Property(e => e.IdJustificacion).HasColumnName("id_justificacion");
            entity.Property(e => e.AprobadoPor).HasColumnName("aprobado_por");
            entity.Property(e => e.CreadoPor).HasColumnName("creado_por");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.FechaAprobacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_aprobacion");
            entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");
            entity.Property(e => e.Motivo).HasColumnName("motivo");

            entity.HasOne(d => d.AprobadoPorNavigation).WithMany(p => p.JustificacionAprobadoPorNavigations)
                .HasForeignKey(d => d.AprobadoPor)
                .HasConstraintName("fk_justificaciones_usuariosaprobado");

            entity.HasOne(d => d.CreadoPorNavigation).WithMany(p => p.JustificacionCreadoPorNavigations)
                .HasForeignKey(d => d.CreadoPor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_justificaciones_usuarioscreado");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Justificacions)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_justificaciones_empleados");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.IdSucursal).HasName("PK__Sucursal__4C75801390930A9D");

            entity.ToTable("Sucursal");

            entity.HasIndex(e => e.Nombre, "UQ__Sucursal__72AFBCC6115C4852").IsUnique();

            entity.Property(e => e.IdSucursal).HasColumnName("id_sucursal");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<TipoEmpleado>(entity =>
        {
            entity.HasKey(e => e.IdTipo).HasName("PK__TipoEmpl__CF901089089B6A80");

            entity.ToTable("TipoEmpleado");

            entity.HasIndex(e => e.NombreTipo, "UQ__TipoEmpl__0C60C00DEF4991D1").IsUnique();

            entity.Property(e => e.IdTipo).HasColumnName("id_tipo");
            entity.Property(e => e.NombreTipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_tipo");
        });

        modelBuilder.Entity<Turno>(entity =>
        {
            entity.HasKey(e => e.IdTurno).HasName("PK__Turno__C68E7397E0A7065F");

            entity.ToTable("Turno");

            entity.HasIndex(e => e.Nombre, "UQ__Turno__72AFBCC6412E0E39").IsUnique();

            entity.Property(e => e.IdTurno).HasColumnName("id_turno");
            entity.Property(e => e.HoraEntrada).HasColumnName("hora_entrada");
            entity.Property(e => e.HoraSalida).HasColumnName("hora_salida");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__4E3E04AD5B1AFC61");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Username, "UQ__Usuario__F3DBC572B2D3263A").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password_hash");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Vacacione>(entity =>
        {
            entity.HasKey(e => e.IdVacacion).HasName("PK__Vacacion__726C3EFEAC07DC35");

            entity.Property(e => e.IdVacacion).HasColumnName("id_vacacion");
            entity.Property(e => e.AprobadoPor).HasColumnName("aprobado_por");
            entity.Property(e => e.CreadoPor).HasColumnName("creado_por");
            entity.Property(e => e.FechaAprobacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_aprobacion");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");

            entity.HasOne(d => d.AprobadoPorNavigation).WithMany(p => p.VacacioneAprobadoPorNavigations)
                .HasForeignKey(d => d.AprobadoPor)
                .HasConstraintName("fk_vacaciones_usuariosaprobado");

            entity.HasOne(d => d.CreadoPorNavigation).WithMany(p => p.VacacioneCreadoPorNavigations)
                .HasForeignKey(d => d.CreadoPor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_vacaciones_usuarioscreado");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Vacaciones)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_vacaciones_empleados");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
