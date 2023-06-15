using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AppNewsApi.Models;

public partial class Sistem21NoticiasdbContext : DbContext
{
    public Sistem21NoticiasdbContext()
    {
    }

    public Sistem21NoticiasdbContext(DbContextOptions<Sistem21NoticiasdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Noticias> Noticias { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=sistemas19.com;database=sistem21_noticiasdb;username=sistem21_noticiasdb;password=sistemas19_", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.5.17-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Noticias>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("noticias");

            entity.HasIndex(e => e.AutorId, "noticias_ibfk_1");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.AutorId)
                .HasColumnType("int(11)")
                .HasColumnName("AutorID");
            entity.Property(e => e.Caption).HasColumnType("text");
            entity.Property(e => e.Contenido).HasColumnType("text");
            entity.Property(e => e.Titulo).HasColumnType("text");

            entity.HasOne(d => d.Autor).WithMany(p => p.Noticias)
                .HasForeignKey(d => d.AutorId)
                .HasConstraintName("noticias_ibfk_1");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("usuarios");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Contraseña).HasColumnType("text");
            entity.Property(e => e.Correo).HasColumnType("text");
            entity.Property(e => e.Nombre).HasColumnType("text");
            entity.Property(e => e.Rol).HasColumnType("text");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
