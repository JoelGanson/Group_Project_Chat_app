using Microsoft.EntityFrameworkCore;
using Group_Project_Chat_app.Models;

namespace Group_Project_Chat_app.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(
                new User { Username = "Admin", Password = "TeamProcrastination",Role="Admin"}
                );
        }
    }
}
