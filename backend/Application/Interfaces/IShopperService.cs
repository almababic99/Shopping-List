using Infrastructure.Models;

namespace Application.Interfaces
{
    public interface IShopperService
    {
        Task<IEnumerable<Shopper>> GetShoppers();
    }
}
