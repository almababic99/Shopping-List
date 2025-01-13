using Domain.DomainModels;

namespace Application.Interfaces
{
    public interface IItemService // An interface defines the signature (method names, parameters, return types) of methods, while the class that implements the interface provides the specific implementation of those method (ItemService)
    {
        Task<IEnumerable<Item>> GetItems();  // asynchronous method that returns a task containing an enumerable collection of Item objects

        Task AddItem(Item itme);
    }
}
