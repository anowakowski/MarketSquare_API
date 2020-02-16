using MarketSquare.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketSquare.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}