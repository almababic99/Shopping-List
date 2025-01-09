using Application.Interfaces;
using Application.Repositories;
using Infrastructure.Models;

namespace Application.Services
{
    public class ShopperService : IShopperService
    {
        private readonly IShopperRepository _shopperRepository;

        public ShopperService(IShopperRepository shopperRepository) 
        {
            _shopperRepository = shopperRepository;
        }

        public async Task<IEnumerable<Shopper>> GetShoppers()
        {
            return await _shopperRepository.GetShoppers();
        }
    }
}
