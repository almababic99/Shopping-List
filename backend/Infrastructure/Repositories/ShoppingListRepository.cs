using Application.Interfaces;
using Domain.DomainModels;
using Infrastructure.Data;
using Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ShoppingListRepository : IShoppingListRepository
    {
        private readonly ShoppingListDbContext _shoppingListDbContext;

        public ShoppingListRepository(ShoppingListDbContext shoppingListDbContext)  // The constructor takes an instance of ShoppingListDbContext as a parameter and assigns it to a private field _shoppingListDbContext. This is a Dependency Injection
        {
            _shoppingListDbContext = shoppingListDbContext;
        }

        public async Task<IEnumerable<ShoppingList>> GetShoppingLists()   // get all shopping lists with Shopper and Items included (shopper and item names)                                                       
        {
            var shoppingLists = await _shoppingListDbContext.ShoppingLists   // without include this would only load ShoppingList data without Shopper and Items
                .Include(s => s.Shopper)   // Include Shopper from ShoppingListDTO
                .Include(s => s.Items)     // Include Items from ShoppingListDTO
                .ToListAsync();  // Get all ShoppingList entities from the DB
            return shoppingLists.Select(shoppingList => ShoppingListMapperEntityToDomain.MapToDomain(shoppingList));  // Map each ShoppingList entity to ShoppingListDomain and return as an IEnumerable<ShoppingList>
        }

        public async Task<IEnumerable<ShoppingList>> GetShoppingListsByShopperId(int shopperId)   // get shopping lists by shopper id
        {
            var shoppingLists = await _shoppingListDbContext.ShoppingLists
                .Where(s => s.ShopperId == shopperId)  // Filter by ShopperId
                .Include(s => s.Shopper)   // Include Shopper details
                .Include(s => s.Items)     // Include Items details
                .ToListAsync();
            return shoppingLists.Select(shoppingList => ShoppingListMapperEntityToDomain.MapToDomain(shoppingList));
        }
    }
}
