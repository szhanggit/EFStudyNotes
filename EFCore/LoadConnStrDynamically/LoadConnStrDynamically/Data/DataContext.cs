using LoadConnStrDynamically.Models;
using Microsoft.EntityFrameworkCore;

namespace LoadConnStrDynamically.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductExpiryScheme> ProductExpirySchemeSets { get; set; }
    }
}
