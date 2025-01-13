using Domain.DomainModels;

namespace Application.Interfaces
{
    public interface IItemRepository // An interface defines the signature (method names, parameters, return types) of methods, while the class that implements the interface provides the specific implementation of those methods (ItemRepository)
    {
        Task<IEnumerable<Item>> GetItems();
    }
}
