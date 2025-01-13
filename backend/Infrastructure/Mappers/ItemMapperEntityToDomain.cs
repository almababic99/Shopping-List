using Domain.DomainModels;
using Infrastructure.Models;

namespace Infrastructure.Mappers
{
    public static class ItemMapperEntityToDomain
    {
        public static Item MapToDomain(ItemEntity item)  // This method maps Item entity model to Domain model
        {
            return new Item
            {
                Id = item.Id,
                Name = item.Name
            };
        }
    }
}
