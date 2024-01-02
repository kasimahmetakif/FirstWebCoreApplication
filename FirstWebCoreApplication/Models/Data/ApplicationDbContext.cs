using Microsoft.EntityFrameworkCore;

namespace FirstWebCoreApplication.Models.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options){ }

        public DbSet<User> User { get; set; }
        public DbSet<Category> Category{ get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<BlogCategory> BlogCategory { get; set; }
        public DbSet<BlogLike> BlogLike { get; set; }
        public DbSet<Comment> Comment { get; set; }

    }
}
