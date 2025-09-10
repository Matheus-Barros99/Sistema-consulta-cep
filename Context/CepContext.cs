using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TesteCandidato1.Models;

namespace TesteCandidato1.Context;

public partial class CepContext : DbContext
{
    public CepContext()
    {
    }

    public CepContext(DbContextOptions<CepContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cep> Ceps { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CEP;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cep>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CEP__3214EC0717B8C2BA");

            entity.ToTable("CEP");

            entity.Property(e => e.Bairro)
                .HasMaxLength(500)
                .HasColumnName("bairro");
            entity.Property(e => e.Cep1)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cep");
            entity.Property(e => e.Complemento)
                .HasMaxLength(500)
                .HasColumnName("complemento");
            entity.Property(e => e.Gia)
                .HasMaxLength(500)
                .HasColumnName("gia");
            entity.Property(e => e.Ibge).HasColumnName("ibge");
            entity.Property(e => e.Localidade)
                .HasMaxLength(500)
                .HasColumnName("localidade");
            entity.Property(e => e.Logradouro)
                .HasMaxLength(500)
                .HasColumnName("logradouro");
            entity.Property(e => e.Uf)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uf");
            entity.Property(e => e.Unidade).HasColumnName("unidade");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
