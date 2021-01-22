using BookShop.Model;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<AppUser> Users { get; set; }
    }
}