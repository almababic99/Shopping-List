using Application.Interfaces;
using Domain.DomainModels;

namespace Application.Services
{
    public class ShoppingListService : IShoppingListService  // ShoppingListService class implements the IShoppingListService interface which means it is expected to define the operations declared in IShoppingListService
    {
        private readonly IShoppingListRepository _shoppingListRepository;

        public ShoppingListService(IShoppingListRepository shoppingListRepository) // The constructor takes an instance of IShoppingListRepository as a parameter and assigns it to a private field _shoppingListRepository. This is a Dependency Injection
        {
            _shoppingListRepository = shoppingListRepository;
        }

        public async Task<IEnumerable<ShoppingList>> GetShoppingLists()  // This method calls the GetShoppingLists() method of the injected repository (_shoppingListsRepository), which will fetch the list of shopping lists from the database
        {
            return await _shoppingListRepository.GetShoppingLists();
        }
    }
}
