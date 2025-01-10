﻿using API.DTOModels;
using Domain.DomainModels;

namespace API.Mappers
{
    public static class ItemMapperDomainToDTO
    {
        public static ItemDTO MapToDTO(ItemDomain item)  // This method maps Item domain model to ItemDTO
        {
            return new ItemDTO
            {
                Id = item.Id,
                Name = item.Name
            };
        }
    }
}
