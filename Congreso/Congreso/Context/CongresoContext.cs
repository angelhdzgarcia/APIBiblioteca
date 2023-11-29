using System;
using System.Collections.Generic;
using Congreso.Models;
using Microsoft.EntityFrameworkCore;

namespace Congreso.Context;

public partial class CongresoContext : DbContext
{
    public CongresoContext()
    {
    }

    public CongresoContext(DbContextOptions<CongresoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Conferencia> Conferencias { get; set; }

    public virtual DbSet<Participante> Participantes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-EM6TT87;Database=Congreso;Trust Server Certificate=true;User Id=sa;Password=12345;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Conferencia>(entity =>
        {
            entity.HasKey(e => e.IdConf).HasName("PK__Conferen__744A9E9CF352A1A9");

            entity.Property(e => e.IdConf)
                .ValueGeneratedNever()
                .HasColumnName("ID_conf");
            entity.Property(e => e.Conferencista)
                .HasMaxLength(35)
                .IsUnicode(false);
            entity.Property(e => e.FkParticipantes).HasColumnName("fk_participantes");
            entity.Property(e => e.Horario).HasColumnType("date");
            entity.Property(e => e.NombreConf)
                .HasMaxLength(40)
                .IsUnicode(false);

            entity.HasOne(d => d.FkParticipantesNavigation).WithMany(p => p.Conferencia)
                .HasForeignKey(d => d.FkParticipantes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Conferenc__fk_pa__267ABA7A");
        });

        modelBuilder.Entity<Participante>(entity =>
        {
            entity.HasKey(e => e.IdParticipantes).HasName("PK__Particip__3DF813EA68E1CE2C");

            entity.Property(e => e.IdParticipantes)
                .ValueGeneratedNever()
                .HasColumnName("ID_participantes");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Twitter)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
