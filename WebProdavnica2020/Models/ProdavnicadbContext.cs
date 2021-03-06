﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebProdavnica2020.Models
{
    public partial class ProdavnicadbContext : DbContext
    {
        public ProdavnicadbContext()
        {
        }

        public ProdavnicadbContext(DbContextOptions<ProdavnicadbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kategorija> Kategorije { get; set; }
        public virtual DbSet<Kupac> Kupci { get; set; }
        public virtual DbSet<Porudzbina> Porudzbine { get; set; }
        public virtual DbSet<Proizvod> Proizvodi { get; set; }
        public virtual DbSet<Stavka> Stavke { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kupac>(entity =>
            {
                entity.Property(e => e.Drzava).HasDefaultValueSql("('Srbija')");

                entity.Property(e => e.Grad).HasDefaultValueSql("('Beograd')");
            });

            modelBuilder.Entity<Porudzbina>(entity =>
            {
                entity.Property(e => e.DatumKupovine).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Kupac)
                    .WithMany(p => p.Porudzbine)
                    .HasForeignKey(d => d.KupacId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Porudzbin__Kupac__4D94879B");
            });

            modelBuilder.Entity<Proizvod>(entity =>
            {
                entity.HasOne(d => d.Kategorija)
                    .WithMany(p => p.Proizvodi)
                    .HasForeignKey(d => d.KategorijaId)
                    .HasConstraintName("FK__Proizvod__Katego__534D60F1");
            });

            modelBuilder.Entity<Stavka>(entity =>
            {
                entity.HasOne(d => d.Porudzbina)
                    .WithMany(p => p.Stavke)
                    .HasForeignKey(d => d.PorudzbinaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Stavka__Porudzbi__5629CD9C");

                entity.HasOne(d => d.Proizvod)
                    .WithMany(p => p.Stavke)
                    .HasForeignKey(d => d.ProizvodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Stavka__Proizvod__571DF1D5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}