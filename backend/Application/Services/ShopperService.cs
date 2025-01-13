using Application.Interfaces;
using Domain.DomainModels;

namespace Application.Services
{
    public class ShopperService : IShopperService  // ShopperService class implements the IShopperService interface which means it is expected to define the operations declared in IShopperService
    {
        private readonly IShopperRepository _shopperRepository;

        public ShopperService(IShopperRepository shopperRepository) // The constructor takes an instance of IShopperRepository as a parameter and assigns it to a private field _shopperRepository. This is a Dependency Injection
        {
            _shopperRepository = shopperRepository;
        }

        public async Task<IEnumerable<Shopper>> GetShoppers()  // This method calls the GetShoppers() method of the injected repository (_shopperRepository), which will fetch the list of shoppers from the database
        {
            return await _shopperRepository.GetShoppers();
        }
    }
}


