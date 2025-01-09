using Domain.DomainModels;
using Infrastructure.Models;

namespace Application.Repositories
{
    public interface IShopperRepository
    {
        Task<IEnumerable<Shopper>> GetShoppers();
    }
}
