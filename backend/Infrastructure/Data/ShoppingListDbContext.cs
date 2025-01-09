using Domain.DomainModels;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ShoppingListDbContext : DbContext
    {
        public ShoppingListDbContext(DbContextOptions<ShoppingListDbContext> options) : base(options) { }

        public DbSet<Shopper> Shoppers { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
