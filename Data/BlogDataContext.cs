using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    public class BlogDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=127.0.0.1;Database=FluentBlog;User ID=sa;password=admin123;Trusted_Connection=False;TrustServerCertificate=True;MultipleActiveResultSets=true");
        }
    }
}