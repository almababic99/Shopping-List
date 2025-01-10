using Infrastructure.EntityModels;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ShoppingListDbContext : DbContext
    {
        public ShoppingListDbContext(DbContextOptions<ShoppingListDbContext> options) : base(options) { }  // this initializes the ShoppingListDbContext with configuration options (DbContextOptions) that specify how to connect to the database

        public DbSet<Shopper> Shoppers { get; set; }  // "Shoppers" table in database
        public DbSet<Item> Items { get; set; }  // "Items" table in database
        public DbSet<ShoppingList> ShoppingLists { get; set; }  // "ShoppingLists" table in database
        public DbSet<ShoppingListItem> ShoppingListItems { get; set; }  // "ShoppingListItems" table in database
    }
}
