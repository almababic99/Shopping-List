using Application.DTOModels;
using Domain.DomainModels;
using Infrastructure.Models;

namespace API.Mappers
{
    public class ShopperMapper
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



//// Map ShopperDTO to ShopperDomain (API Layer to Domain Layer)
//public static ShopperDomain MapToDomain(ShopperDTO shopperDTO)
//{
//    return new ShopperDomain
//    {
//        Id = shopperDTO.Id,
//        Name = shopperDTO.Name
//    };
//}