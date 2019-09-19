using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace powerplatformevents.Models
{
    public partial class ppeventsContext : DbContext
    {
        public ppeventsContext(DbContextOptions<ppeventsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<Organisers> Organisers { get; set; }
        public virtual DbSet<Participants> Participants { get; set; }
        public virtual DbSet<Sessions> Sessions { get; set; }
        public virtual DbSet<Speakers> Speakers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            { }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Events>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.Country).HasMaxLength(100);

                entity.Property(e => e.DateEnd).HasColumnType("datetime");

                entity.Property(e => e.DateStart).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Zip).HasMaxLength(10);
            });

            modelBuilder.Entity<Organisers>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Organisers)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Organisers_Events");

                entity.HasOne(d => d.Speaker)
                    .WithMany(p => p.Organisers)
                    .HasForeignKey(d => d.SpeakerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Organisers_Speakers");
            });

            modelBuilder.Entity<Participants>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Participants)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Participants_Events");
            });

            modelBuilder.Entity<Sessions>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Audience).HasMaxLength(100);

                entity.Property(e => e.Level).HasMaxLength(3);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sessions_Events");

                entity.HasOne(d => d.Speaker)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.SpeakerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sessions_Speakers");
            });

            modelBuilder.Entity<Speakers>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Aadid)
                    .HasColumnName("AADId")
                    .HasMaxLength(200);

                entity.Property(e => e.BlogUrl).HasMaxLength(50);

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LinkedInProfile).HasMaxLength(50);

                entity.Property(e => e.MobilePhoneNumber).HasMaxLength(50);

                entity.Property(e => e.Mvp)
                    .HasColumnName("MVP")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NickName).HasMaxLength(50);

                entity.Property(e => e.ProfilePhotoUrl).HasMaxLength(250);

                entity.Property(e => e.TwitterAddress).HasMaxLength(20);
            });
        }
    }
}
