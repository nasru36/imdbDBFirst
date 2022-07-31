using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;

namespace imdbDBFirstDataAccessLayer.Models
{
    public partial class imdbContext : DbContext
    {
        public imdbContext()
        {
        }

        public imdbContext(DbContextOptions<imdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Movie> Movies { get; set; } = null!;
        public virtual DbSet<Producer> Producers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var config = builder.Build();
            var connectionString = config.GetConnectionString("IMDBDBConnectionString");
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB ; Database = imdb ; Trusted_Connection = true");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.ToTable("Actor");

                entity.Property(e => e.ActorId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ActorID");

                entity.Property(e => e.ActorName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre");

                entity.Property(e => e.GenreId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GenreID");

                entity.Property(e => e.GenreType)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("Movie");

                entity.Property(e => e.MovieId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MovieID");

                entity.Property(e => e.ActorId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ActorID");

                entity.Property(e => e.GenereId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GenereID");

                entity.Property(e => e.MovieTitle)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ProducerId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ProducerID");

                entity.Property(e => e.ReleaseDate).HasColumnType("date");

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.ActorId)
                    .HasConstraintName("FK__Movie__ActorID__3D5E1FD2");

                entity.HasOne(d => d.Genere)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.GenereId)
                    .HasConstraintName("FK__Movie__GenereID__3C69FB99");

                entity.HasOne(d => d.Producer)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.ProducerId)
                    .HasConstraintName("FK__Movie__ProducerI__3E52440B");
            });

            modelBuilder.Entity<Producer>(entity =>
            {
                entity.ToTable("Producer");

                entity.Property(e => e.ProducerId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ProducerID");

                entity.Property(e => e.ProducerName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
