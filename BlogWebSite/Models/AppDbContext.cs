using Microsoft.EntityFrameworkCore;

namespace BlogWebSite.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {  
           
        }      
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>().HasData(new Category() { Id = 1, Name = "Category1" });
            modelBuilder.Entity<Category>().HasData(new Category() { Id = 2, Name = "Category2" });
            modelBuilder.Entity<Category>().HasData(new Category() { Id = 3, Name = "Category3" });

            base.OnModelCreating(modelBuilder);

        }
    }
}
