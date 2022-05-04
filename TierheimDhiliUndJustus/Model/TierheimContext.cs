using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TierheimDhiliUndJustus.Model
{
    public partial class TierheimContext : DbContext
    {
        public TierheimContext()
        {
        }

        public TierheimContext(DbContextOptions<TierheimContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kunde> Kundes { get; set; } = null!;
        public virtual DbSet<Spende> Spendes { get; set; } = null!;
        public virtual DbSet<Termin> Termins { get; set; } = null!;
        public virtual DbSet<Terminart> Terminarts { get; set; } = null!;
        public virtual DbSet<Tier> Tiers { get; set; } = null!;
        public virtual DbSet<Tierart> Tierarts { get; set; } = null!;
        public virtual DbSet<Tierrasse> Tierrasses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("datasource=philipp268.ddnss.de;database=tierheim;userid=nervi;password=nervinervt1234", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.22-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Kunde>(entity =>
            {
                entity.HasKey(e => e.IdKunde)
                    .HasName("PRIMARY");

                entity.ToTable("kunde");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_bin");

                entity.Property(e => e.IdKunde).HasColumnName("ID_Kunde");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Passwort).HasMaxLength(45);
            });

            modelBuilder.Entity<Spende>(entity =>
            {
                entity.HasKey(e => e.IdSpende)
                    .HasName("PRIMARY");

                entity.ToTable("spende");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_bin");

                entity.HasIndex(e => e.FkKundeSpende, "fk_Spende_Kunde1_idx");

                entity.Property(e => e.IdSpende).HasColumnName("ID_Spende");

                entity.Property(e => e.Betrag).HasPrecision(10);

                entity.Property(e => e.FkKundeSpende).HasColumnName("FK_Kunde_Spende");

                entity.HasOne(d => d.FkKundeSpendeNavigation)
                    .WithMany(p => p.Spendes)
                    .HasForeignKey(d => d.FkKundeSpende)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Spende_Kunde1");
            });

            modelBuilder.Entity<Termin>(entity =>
            {
                entity.HasKey(e => e.IdTermin)
                    .HasName("PRIMARY");

                entity.ToTable("termin");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_bin");

                entity.HasIndex(e => e.FkKundeTermin, "fk_Termin_Kunde1_idx");

                entity.HasIndex(e => e.FkTierTermin, "fk_Termin_Tier");

                entity.HasIndex(e => e.FkTerminartTermin, "fk_termin_terminart1_idx");

                entity.Property(e => e.IdTermin).HasColumnName("ID_Termin");

                entity.Property(e => e.FkKundeTermin).HasColumnName("FK_Kunde_Termin");

                entity.Property(e => e.FkTerminartTermin).HasColumnName("FK_Terminart_Termin");

                entity.Property(e => e.FkTierTermin).HasColumnName("FK_Tier_Termin");

                entity.Property(e => e.Uhrzeit).HasColumnType("time");

                entity.HasOne(d => d.FkKundeTerminNavigation)
                    .WithMany(p => p.Termins)
                    .HasForeignKey(d => d.FkKundeTermin)
                    .HasConstraintName("fk_Termin_Kunde1");

                entity.HasOne(d => d.FkTerminartTerminNavigation)
                    .WithMany(p => p.Termins)
                    .HasForeignKey(d => d.FkTerminartTermin)
                    .HasConstraintName("fk_termin_terminart1");

                entity.HasOne(d => d.FkTierTerminNavigation)
                    .WithMany(p => p.Termins)
                    .HasForeignKey(d => d.FkTierTermin)
                    .HasConstraintName("fk_Termin_Tier");
            });

            modelBuilder.Entity<Terminart>(entity =>
            {
                entity.HasKey(e => e.IdTerminart)
                    .HasName("PRIMARY");

                entity.ToTable("terminart");

                entity.Property(e => e.IdTerminart).HasColumnName("ID_terminart");

                entity.Property(e => e.Bezeichnung)
                    .HasMaxLength(45)
                    .HasColumnName("bezeichnung");
            });

            modelBuilder.Entity<Tier>(entity =>
            {
                entity.HasKey(e => e.IdTier)
                    .HasName("PRIMARY");

                entity.ToTable("tier");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_bin");

                entity.HasIndex(e => e.FkTierrasseTier, "fk_Tier_Tierrasse1_idx");

                entity.Property(e => e.IdTier).HasColumnName("ID_Tier");

                entity.Property(e => e.Beschreibung).HasMaxLength(300);

                entity.Property(e => e.FkTierrasseTier).HasColumnName("FK_Tierrasse_Tier");

                entity.Property(e => e.Geschlecht)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.Tiername).HasMaxLength(20);

                entity.HasOne(d => d.FkTierrasseTierNavigation)
                    .WithMany(p => p.Tiers)
                    .HasForeignKey(d => d.FkTierrasseTier)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Tier_Tierrasse1");
            });

            modelBuilder.Entity<Tierart>(entity =>
            {
                entity.HasKey(e => e.IdTierart)
                    .HasName("PRIMARY");

                entity.ToTable("tierart");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_bin");

                entity.Property(e => e.IdTierart).HasColumnName("ID_Tierart");

                entity.Property(e => e.Tierartname).HasMaxLength(25);
            });

            modelBuilder.Entity<Tierrasse>(entity =>
            {
                entity.HasKey(e => e.IdTierrasse)
                    .HasName("PRIMARY");

                entity.ToTable("tierrasse");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_bin");

                entity.HasIndex(e => e.FkTierartTierrasse, "FK_Tierrasse_Tierart");

                entity.Property(e => e.IdTierrasse).HasColumnName("ID_Tierrasse");

                entity.Property(e => e.FkTierartTierrasse).HasColumnName("FK_Tierart_Tierrasse");

                entity.Property(e => e.Tierrassenamen).HasMaxLength(25);

                entity.HasOne(d => d.FkTierartTierrasseNavigation)
                    .WithMany(p => p.Tierrasses)
                    .HasForeignKey(d => d.FkTierartTierrasse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tierrasse_Tierart");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
