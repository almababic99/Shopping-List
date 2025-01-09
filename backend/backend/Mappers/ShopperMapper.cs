using Application.DTOModels;
using Infrastructure.Models;

namespace API.Mappers
{
    public static class ShopperMapper
    {
        public static ShopperDTO MapToDTO(Shopper shopper)
        {
            return new ShopperDTO
            {
                Id = shopper.Id,
                Name = shopper.Name
            };
        }
    }
}



