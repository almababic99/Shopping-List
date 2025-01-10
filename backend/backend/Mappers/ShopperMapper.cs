using API.DTOModels;
using Application.Models;

namespace API.Mappers
{
    public static class ShopperMapper
    {
        public static ShopperDTO MapToDTO(Shopper shopper)  // This method maps Shopper model to ShopperDTO
        {
            return new ShopperDTO
            {
                Id = shopper.Id,
                Name = shopper.Name
            };
        }
    }
}



