using Application.Interfaces;
using Domain.DomainModels;
using Infrastructure.Data;
using Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository // ItemRepository class implements IItemRepository interface which means it is expected to define the operations declared in IItemRepository
    {
        private readonly ShoppingListDbContext _shoppingListDbContext;
        public ItemRepository(ShoppingListDbContext shoppingListDbContext)  // The constructor takes an instance of ShoppingListDbContext as a parameter and assigns it to a private field _shoppingListDbContext. This is a Dependency Injection
        {
            _shoppingListDbContext = shoppingListDbContext;
        }

        public async Task<IEnumerable<ItemDomain>> GetItems()
        {
            var items = await _shoppingListDbContext.Items.ToListAsync();  // Get all Item entities from the DB
            return items.Select(item => ItemMapperEntityToDomain.MapToDomain(item));  // Map each Item entity to ItemDomain and return as an IEnumerable<ItemDomain>
        }
    }
}
