using FA.JustBlog.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Core.Data
{
    public class JustBlogContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public JustBlogContext()
        {
        }

        public JustBlogContext(DbContextOptions<JustBlogContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTagMap> PostTagMaps { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Posts)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<PostTagMap>()
                .HasKey(pt => new { pt.PostId, pt.TagId });

            modelBuilder.Entity<Tag>()
                .HasMany(t => t.PostTagMaps)
                .WithOne(pt => pt.Tag)
                .HasForeignKey(pt => pt.TagId);

            modelBuilder.Entity<Post>()
                .HasMany(p => p.PostTagMaps)
                .WithOne(pt => pt.Post)
                .HasForeignKey(pt => pt.PostId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
