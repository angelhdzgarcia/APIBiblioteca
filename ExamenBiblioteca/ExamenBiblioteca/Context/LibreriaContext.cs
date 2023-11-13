using System;
using System.Collections.Generic;
using ExamenBiblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamenBiblioteca.Context;

public partial class LibreriaContext : DbContext
{
    public LibreriaContext()
    {
    }

    public LibreriaContext(DbContextOptions<LibreriaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autor> Autors { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-EM6TT87;Database=Libreria;Trust Server Certificate=true;User Id=sa;Password=12345;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__autor__3214EC0713CB3ECB");

            entity.ToTable("autor");

            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__libro__3214EC071FFE865F");

            entity.ToTable("libro");

            entity.Property(e => e.AutorId).HasColumnName("autorId");
            entity.Property(e => e.Capitulos).HasColumnName("capitulos");
            entity.Property(e => e.Paginas).HasColumnName("paginas");
            entity.Property(e => e.Precio).HasColumnName("precio");
            entity.Property(e => e.Titulo)
                .HasMaxLength(255)
                .HasColumnName("titulo");

            entity.HasOne(d => d.Autor).WithMany(p => p.Libros)
                .HasForeignKey(d => d.AutorId)
                .HasConstraintName("FK__libro__autorId__267ABA7A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
