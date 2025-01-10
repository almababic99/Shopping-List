using Domain.DomainModels;
using Infrastructure.Models;

namespace Infrastructure.Mappers
{
    public static class ShopperMapperEntityToDomain
    {
        public static ShopperDomain MapToDomain(Shopper shopper)  // This method maps Shopper entity model to Domain model
        {
            return new ShopperDomain
            {
                Id = shopper.Id,
                Name = shopper.Name
            };
        }
    }
}
