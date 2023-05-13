using System;
using System.Collections.Generic;
using BeerapiNet7._0.Models;
using Microsoft.EntityFrameworkCore;

namespace BeerapiNet7._0;

public partial class BeerDbContext : DbContext
{
    public BeerDbContext()
    {
    }

    public BeerDbContext(DbContextOptions<BeerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Beer> Beers { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<TypeBeer> TypeBeers { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Beer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BEER__3213E83FA087DD7C");

            entity.ToTable("BEER");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Alcohol).HasColumnName("alcohol");
            entity.Property(e => e.IdCompany).HasColumnName("id_company");
            entity.Property(e => e.IdCountry).HasColumnName("id_country");
            entity.Property(e => e.IdType).HasColumnName("id_type");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.IdCompanyNavigation).WithMany(p => p.Beers)
                .HasForeignKey(d => d.IdCompany)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BEER__id_company__2C3393D0");

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.Beers)
                .HasForeignKey(d => d.IdCountry)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BEER__id_country__2A4B4B5E");

            entity.HasOne(d => d.IdTypeNavigation).WithMany(p => p.Beers)
                .HasForeignKey(d => d.IdType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BEER__id_type__2B3F6F97");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__COMPANY__3213E83F84374F5A");

            entity.ToTable("COMPANY");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__COUNTRY__3213E83FAD766C36");

            entity.ToTable("COUNTRY");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TypeBeer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TYPE_BEE__3213E83FB37FD89E");

            entity.ToTable("TYPE_BEER");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
