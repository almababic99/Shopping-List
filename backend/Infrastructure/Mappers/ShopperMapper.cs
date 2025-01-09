using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DomainModels;
using Infrastructure.Models;

namespace Infrastructure.Mappers
{
    public static class ShopperMapper
    {
        // Map Shopper (Entity) to ShopperDomain (Infrastructure Layer to Domain Layer)
        public static ShopperDomain MapToDomain(Shopper shopper)
        {
            return new ShopperDomain
            {
                Id = shopper.Id,
                Name = shopper.Name
            };
        }

        // Map ShopperDomain to Shopper (Domain Layer to Infrastructure Layer)
        public static Shopper MapToEntity(ShopperDomain shopperDomain)
        {
            return new Shopper
            {
                Id = shopperDomain.Id,
                Name = shopperDomain.Name
            };
        }

    }
}
