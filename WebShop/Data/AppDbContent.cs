using Microsoft.EntityFrameworkCore;
using WebShop.Data.Models;

namespace WebShop.Data
{
    public class AppDbContent: DbContext
    {
        public DbSet<Car> Car { get; set; } = null!;
        public DbSet<Category> Category { get; set; } = null!;

        public AppDbContent(DbContextOptions<AppDbContent> options)
            : base(options) { }
        
    }

}
