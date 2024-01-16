using Microsoft.EntityFrameworkCore;
using Web_store.Data.Models;

namespace Web_store.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() {}
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Item> Item { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
