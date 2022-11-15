using Microsoft.EntityFrameworkCore;
using WebShop.Data.Models;

namespace WebShop.Data
{
    public class AppDbContent: DbContext
    {
        public AppDbContent(DbContextOptions options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\\MSSQLLocalDB;Database=Shop;Trusted_Connection=True;");
        }
        

        public DbSet<Car> Car { get; set; }
        public DbSet<Category> Category { get; set; }
    }

}
