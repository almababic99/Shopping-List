using Application.Repositories;
using Domain.DomainModels;
using Infrastructure.Data;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ShopperRepository : IShopperRepository  // ShopperRepository class implements IShopperRepository interface
    {
        private readonly ShoppingListDbContext _shoppingListDbContext;
        public ShopperRepository(ShoppingListDbContext shoppingListDbContext) 
        {
            _shoppingListDbContext = shoppingListDbContext;
        }

        public async Task<IEnumerable<Shopper>> GetShoppers()
        {
            return await _shoppingListDbContext.Shoppers.ToListAsync();
        }
    }
}
