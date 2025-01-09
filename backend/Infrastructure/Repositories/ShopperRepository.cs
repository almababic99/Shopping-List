using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data;
using Infrastructure.Models;

namespace Infrastructure.Repositories
{
    public class ShopperRepository : IShopperRepository
    {
        private readonly ShoppingListDbContext _shoppingListDbContext;
        public ShopperRepository(ShoppingListDbContext shoppingListDbContext) 
        {
            _shoppingListDbContext = shoppingListDbContext;
        }

        public IEnumerable<Shopper> GetShoppers()
        {
            return _shoppingListDbContext.Shoppers.ToList();
        }
    }
}
