using Domain.DomainModels;
using Infrastructure.Models;

namespace Infrastructure.Mappers
{
    public static class ShopperMapperDomainToEntity
    {
        public static ShopperEntity MapToEntity(Shopper shopper)  // This method maps Domain model to Item entity model 
        {
            return new ShopperEntity
            {
                Id = shopper.Id,
                Name = shopper.Name
            };
        }
    }
}
