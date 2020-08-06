using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

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

        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<PictureInformation> PictureInformation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>(entity =>
            {
                entity.Property(e => e.LogDateTime)
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(getdate())");

                entity.Property(e => e.LogText)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.PictureReference)
                    .WithMany(p => p.Log)
                    .HasForeignKey(d => d.PictureReferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Log_PictureInformation");
            });

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
