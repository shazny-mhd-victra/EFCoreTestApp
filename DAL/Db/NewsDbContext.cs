using System;
using System.Collections.Generic;
using System.Data;
using DAL.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Db
{
    public partial class NewsDbContext : DbContext
    {
        public NewsDbContext()
        {
        }

        public NewsDbContext(DbContextOptions<NewsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<News> News { get; set; } = null!;
        public virtual DbSet<Priority> Priorities { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EFCoreTestNewsDb;Integrated Security=True;Pooling=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.NewsId).HasColumnName("_news_id");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("_description");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("_end_date");

                entity.Property(e => e.IsDeleted).HasColumnName("_is_deleted");

                entity.Property(e => e.PrimaryImage)
                    .IsUnicode(false)
                    .HasColumnName("_primary_image");

                entity.Property(e => e.PriorityId).HasColumnName("_priority_id");

                entity.Property(e => e.SecondaryImage)
                    .IsUnicode(false)
                    .HasColumnName("_secondary_image");

                entity.Property(e => e.ShortDescription)
                    .IsUnicode(false)
                    .HasColumnName("_short_description");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("_start_date");

                entity.Property(e => e.Title)
                    .IsUnicode(false)
                    .HasColumnName("_title");

                entity.Property(e => e.VideoUrl)
                    .IsUnicode(false)
                    .HasColumnName("_video_url");

                entity.HasOne(d => d.Priority)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.PriorityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__News___priority___267ABA7A");
            });

            modelBuilder.Entity<Priority>(entity =>
            {
                entity.Property(e => e.PriorityId).HasColumnName("_priority_id");

                entity.Property(e => e.Active).HasColumnName("_active");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("_description");

                entity.Property(e => e.Level).HasColumnName("_level");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    }
}
