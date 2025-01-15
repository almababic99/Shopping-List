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

        public async Task<IEnumerable<Shopper>> GetShoppers()   // get all shoppers                                                         
        {
            var shoppers = await _shoppingListDbContext.Shoppers.ToListAsync();  // Get all Shopper entities from the DB
            return shoppers.Select(shopper => ShopperMapperEntityToDomain.MapToDomain(shopper));  // Map each Shopper entity to ShopperDomain and return as an IEnumerable<Shopper>
        }

        public async Task<Shopper?> GetShopperById(int id)  // get shopper by id
        {
            var shopperEntity = await _shoppingListDbContext.Shoppers.FirstOrDefaultAsync(i => i.Id == id);
            return shopperEntity != null ? ShopperMapperEntityToDomain.MapToDomain(shopperEntity) : null;
            // if shopperEntity is not null method ShopperMapperEntityToDomain.MapToDomain(shopperEntity) is called to map entity model to domain model
            // if shopperEntity is null it returns null
        }
    }
}