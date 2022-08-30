using BlogWebSite.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogWebSite.Repository
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
