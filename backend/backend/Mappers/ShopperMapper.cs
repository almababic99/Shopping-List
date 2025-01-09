using API.DTOModels;
using Domain.DomainModels;

namespace API.Mappers
{
    public static class ShopperMapper
    {
        // Map ShopperDTO to ShopperDomain (API Layer to Domain Layer)
        public static ShopperDomain MapToDomain(ShopperDTO shopperDTO)
        {
            return new ShopperDomain
            {
                Id = shopperDTO.Id,
                Name = shopperDTO.Name
            };
        }

        // Map ShopperDomain to ShopperDTO (Domain Layer to API Layer)
        public static ShopperDTO MapToDTO(ShopperDomain shopperDomain)
        {
            return new ShopperDTO
            {
                Id = shopperDomain.Id,
                Name = shopperDomain.Name
            };
        }
    }
}
