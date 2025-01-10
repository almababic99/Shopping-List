using Application.Models;

namespace Application.Interfaces
{
    public interface IShopperRepository  // An interface defines the signature (method names, parameters, return types) of methods, while the class that implements the interface provides the specific implementation of those method (ShopperRepository)
    {
        Task<IEnumerable<Shopper>> GetShoppers();  // asynchronous method that returns a task containing an enumerable collection of Shopper objects
    }
}
