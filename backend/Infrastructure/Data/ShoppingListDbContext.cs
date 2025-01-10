using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ShoppingListDbContext : DbContext
    {
        public ShoppingListDbContext(DbContextOptions<ShoppingListDbContext> options) : base(options) { }  // this initializes the ShoppingListDbContext with configuration options (DbContextOptions) that specify how to connect to the database

        public DbSet<Shopper> Shoppers { get; set; }  // this represents the "Shoppers" table in the database
        public DbSet<Item> Items { get; set; }  // this represents the "Items" table in the database
    }
}
