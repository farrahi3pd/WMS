using Microsoft.Azure.Documents;
using Microsoft.EntityFrameworkCore;
using RegisterPeople.Models;

namespace RegisterPeople.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
