using Microsoft.EntityFrameworkCore;
using video_hosting.Models;

namespace video_hosting.Services
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Video> Videos => Set<Video>(); 
        
        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=database.db");
        }
    }
}
