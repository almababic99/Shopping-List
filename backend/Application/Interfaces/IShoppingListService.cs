using Domain.DomainModels;

namespace Application.Interfaces
{
    public interface IShoppingListService
    {
        Task<IEnumerable<ShoppingList>> GetShoppingLists();

        Task<IEnumerable<ShoppingList>> GetShoppingListsByShopperId(int shopperId);
    }
}
