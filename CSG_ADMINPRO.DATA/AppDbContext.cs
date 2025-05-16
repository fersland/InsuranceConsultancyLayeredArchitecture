using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CSG_ADMINPRO.DOMAIN.Entities;
using CSG_ADMINPRO.DOMAIN.Entities.CSG_ADMINPRO.DOMAIN.Entities.CSG_ADMINPRO.DOMAIN.Entities;

namespace CSG_ADMINPRO.DATA;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asegurado> Asegurados { get; set; }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Consulta> Consultas { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Seguro> Seguros { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<TicketsComentario> TicketsComentarios { get; set; }

    public virtual DbSet<TicketsTipo> TicketsTipos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Reclamacion> Reclamaciones { get; set; }

    public virtual DbSet<Poliza> Polizas { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asegurado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Asegurad__3214EC077F9F108A");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Asegurados)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Asegurado__Clien__22751F6C");

            entity.HasOne(d => d.Seguro).WithMany(p => p.Asegurados)
                .HasForeignKey(d => d.SeguroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Asegurado__Segur__236943A5");
        });

        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.CitaId).HasName("PK__Citas__F0E2D9D2A825B1FB");

            entity.Property(e => e.FechaActualizcion).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.Motivo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Notas).HasColumnType("text");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Cliente).WithMany(p => p.Cita)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Citas__ClienteId__46B27FE2");

            entity.HasOne(d => d.Estado).WithMany(p => p.Cita)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Citas__EstadoId__4A8310C6");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clientes__3214EC076928CF58");

            entity.Property(e => e.Cedula).HasMaxLength(10);
            entity.Property(e => e.NombreCliente).HasMaxLength(40);
            entity.Property(e => e.Telefono).HasMaxLength(10);
        });

        modelBuilder.Entity<Consulta>(entity =>
        {
            entity.HasKey(e => e.ConsultaId).HasName("PK__Consulta__7D0B7DCC6A475DD4");

            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.FechaActualizcion).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.Notas).HasColumnType("text");
            entity.Property(e => e.Resolucion).HasColumnType("text");

            entity.HasOne(d => d.Cita).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.CitaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Consultas__CitaI__4D5F7D71");

            entity.HasOne(d => d.Estado).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Consultas__Estad__4E53A1AA");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Estados__3214EC0779078810");

            entity.Property(e => e.NombreEstado)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Seguro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Seguros__3214EC078F019190");

            entity.Property(e => e.Asegurada).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Codigo).HasMaxLength(50);
            entity.Property(e => e.NombreSeguro).HasMaxLength(150);
            entity.Property(e => e.Prima).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(s => s.Id);
            entity.Property(s => s.Id).ValueGeneratedOnAdd();

            entity.Property(e => e.NombreServicio)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tickets__3214EC0756210803");

            entity.Property(e => e.Asunto)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.FechaActualizacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Actualizacion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion");
            entity.Property(e => e.FechaResolucion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Resolucion");
            entity.Property(e => e.Prioridad)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Cliente).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tickets__Descrip__30C33EC3");

            entity.HasOne(d => d.Estado).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tickets__EstadoI__32AB8735");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tickets__Usuario__31B762FC");
        });

        modelBuilder.Entity<TicketsComentario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tickets___3214EC07E6AA8E45");

            entity.ToTable("Tickets_Comentarios");

            entity.Property(e => e.Comentario).HasColumnType("text");
            entity.Property(e => e.FechaComentario)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_comentario");

            entity.HasOne(d => d.TicketComentarioEstadoNavigation).WithMany(p => p.TicketsComentarios)
                .HasForeignKey(d => d.TicketComentarioEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tickets_C__Ticke__37703C52");

            entity.HasOne(d => d.Ticket).WithMany(p => p.TicketsComentarios)
                .HasForeignKey(d => d.TicketId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tickets_C__Ticke__3587F3E0");

            entity.HasOne(d => d.Usuario).WithMany(p => p.TicketsComentarios)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tickets_C__Usuar__367C1819");
        });

        modelBuilder.Entity<TicketsTipo>(entity =>
        {
            entity.HasKey(e => e.TicketTpoId).HasName("PK__Tickets___C5CCEC49B27E2DAC");

            entity.ToTable("Tickets_Tipos");

            entity.Property(e => e.NombreTicketTipo)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.TicketTipoEstadoNavigation).WithMany(p => p.TicketsTipos)
                .HasForeignKey(d => d.TicketTipoEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tickets_T__Ticke__2DE6D218");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC0754151AEE");

            entity.Property(e => e.ClaveUsuario)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CorreoUsuario)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FechaCrecion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.Estado).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuarios__Estado__2B0A656D");
        });

        modelBuilder.Entity<Poliza>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.NumeroPoliza)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.MontoAsegurado)
                .HasColumnType("decimal(18, 2)");

            entity.Property(e => e.Prima)
                .HasColumnType("decimal(18, 2)");

            entity.Property(e => e.FechaEmision)
                .HasColumnType("datetime");

            entity.Property(e => e.FechaVencimiento)
                .HasColumnType("datetime");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime");

            entity.Property(e => e.Notas)
                .HasColumnType("text");

            entity.HasOne(p => p.Cliente)
                .WithMany(c => c.Polizas)
                .HasForeignKey(p => p.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(p => p.Seguro)
                .WithMany()
                .HasForeignKey(p => p.SeguroId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });


        modelBuilder.Entity<Reclamacion>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Resolucion).HasColumnType("text");

            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.MontoReclamado)
                .HasColumnType("decimal(18, 2)");

            entity.Property(e => e.FechaReclamacion).HasColumnType("datetime");
            entity.Property(e => e.FechaResolucion).HasColumnType("datetime");

            entity.HasOne(r => r.Poliza)
                .WithMany(p => p.Reclamaciones)
                .HasForeignKey(r => r.PolizaId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(r => r.Cliente)
                .WithMany()
                .HasForeignKey(r => r.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
