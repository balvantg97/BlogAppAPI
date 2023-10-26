using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BlogAppAPI.Models.DB
{
    public partial class BlogAppDBContext : DbContext
    {
        public BlogAppDBContext()
        {
        }

        public BlogAppDBContext(DbContextOptions<BlogAppDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BlogDetail> BlogDetails { get; set; }
        public virtual DbSet<CommentDetail> CommentDetails { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogDetail>(entity =>
            {
                entity.HasKey(e => e.BlogId)
                    .HasName("PK__BlogDeta__54379E30133EF4CF");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<CommentDetail>(entity =>
            {
                entity.ToTable("CommentDetail");

                entity.Property(e => e.CommentText).HasColumnName("commentText");

                entity.Property(e => e.CommentedBy)
                    .HasMaxLength(100)
                    .HasColumnName("commentedBy");

                entity.Property(e => e.CommentedOn)
                    .HasMaxLength(30)
                    .HasColumnName("commentedOn");

                entity.Property(e => e.ReplyText).HasColumnName("replyText");
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserDeta__1788CC4CA033479D");

                entity.Property(e => e.UserId).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(20);

                entity.Property(e => e.FirstName).HasMaxLength(20);

                entity.Property(e => e.LastName).HasMaxLength(10);

                entity.Property(e => e.LastUpdated).HasMaxLength(20);

                entity.Property(e => e.Password).HasMaxLength(10);

                entity.Property(e => e.UserName).HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
