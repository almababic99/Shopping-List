using Application.Interfaces;
using Domain.DomainModels;
using Infrastructure.Data;
using Infrastructure.Mappers;
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

        public async Task<IEnumerable<ShopperDomain>> GetShoppers()                                                            
        {
            var shoppers = await _shoppingListDbContext.Shoppers.ToListAsync();  // Get all Shopper entities from the DB
            return shoppers.Select(shopper => ShopperMapperEntityToDomain.MapToDomain(shopper));  // Map each Shopper entity to ShopperDomain and return as an IEnumerable<ShopperDomain>
        }
    }
}