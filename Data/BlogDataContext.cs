using Blog.Mappings;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    public class BlogDataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<UserBlog> UserBlogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
           options.UseSqlServer("Server=127.0.0.1;Database=Blog;User ID=sa;password=admin123;Trusted_Connection=False;TrustServerCertificate=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new UserBlogMap());
            modelBuilder.ApplyConfiguration(new PostMap());
        }
    }
}