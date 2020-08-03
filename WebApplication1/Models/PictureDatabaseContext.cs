﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyWebAppGit.Models
{
    public partial class PictureDatabaseContext : DbContext
    {
        public PictureDatabaseContext()
        {
        }

        public PictureDatabaseContext(DbContextOptions<PictureDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PictureInformation> PictureInformation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=KAY-PC\\KAYSQLEXPRESS;Database=PictureDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PictureInformation>(entity =>
            {
                entity.HasIndex(e => e.PicturePath)
                    .HasName("i1")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateAdded).HasColumnName("Date Added");

                entity.Property(e => e.DateModified).HasColumnName("Date modified");

                entity.Property(e => e.PicturePath)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}