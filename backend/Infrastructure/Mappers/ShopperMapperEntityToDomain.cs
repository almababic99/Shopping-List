using Domain.DomainModels;
using Infrastructure.Models;

namespace Infrastructure.Mappers
{
    public static class ShopperMapperEntityToDomain
    {
        public static Shopper MapToDomain(ShopperEntity shopper)  // This method maps Shopper entity model to Domain model
        {
            return new Shopper
            {
                Id = shopper.Id,
                Name = shopper.Name
            };
        }
    }
}
