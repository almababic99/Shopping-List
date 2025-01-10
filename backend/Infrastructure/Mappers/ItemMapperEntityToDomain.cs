using Domain.DomainModels;
using Infrastructure.Models;

namespace Infrastructure.Mappers
{
    public static class ItemMapperEntityToDomain
    {
        public static ItemDomain MapToDomain(Item item)  // This method maps Item entity model to Domain model
        {
            return new ItemDomain
            {
                Id = item.Id,
                Name = item.Name
            };
        }
    }
}
