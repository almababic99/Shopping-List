using Application.Interfaces;
using Application.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ShopperRepository : IShopperRepository  // ShopperRepository class implements IShopperRepository interface which means it is expected to define the operations declared in IShopperRepository
    {
        private readonly ShoppingListDbContext _shoppingListDbContext;
        public ShopperRepository(ShoppingListDbContext shoppingListDbContext)  // The constructor takes an instance of ShoppingListDbContext as a parameter and assigns it to a private field _shoppingListDbContext. This is a Dependency Injection
        {
            _shoppingListDbContext = shoppingListDbContext;
        }

        public async Task<IEnumerable<Shopper>> GetShoppers()  // asynchronous method that retrieves all the Shopper entities from the database
                                                               // Task is a type that represents an operation that will complete in the future; IEnumerable<Shopper> indicates that the result will be an enumeration (such as a list or array) of Shopper objects
        {
            return await _shoppingListDbContext.Shoppers.ToListAsync(); // retrieving all records from the Shoppers table in the database and returning them as a list
        }
    }
}
