using Application.Interfaces;
using Domain.DomainModels;

namespace Application.Services
{
    public class ItemService : IItemService  // ItemService class implements the IItemService interface which means it is expected to define the operations declared in IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository) // The constructor takes an instance of IItemRepository as a parameter and assigns it to a private field _itemRepository. This is a Dependency Injection
        {
            _itemRepository = itemRepository;
        }

        public async Task<IEnumerable<ItemDomain>> GetItems()  // This method calls the GetItems() method of the injected repository (_itemRepository), which will fetch the list of items from the database
        {
            return await _itemRepository.GetItems();
        }
    }
}
