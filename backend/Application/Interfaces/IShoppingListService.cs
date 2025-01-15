using Domain.DomainModels;

namespace Application.Interfaces
{
    public interface IShoppingListService
    {
        Task<IEnumerable<ShoppingList>> GetShoppingLists();
    }
}
