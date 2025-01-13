using Domain.DomainModels;
using Infrastructure.Models;

namespace Infrastructure.Mappers
{
    public static class ItemMapperDomainToEntity
    {
        public static ItemEntity MapToEntity(Item item)  // This method maps Domain model to Item entity model 
        {
            return new ItemEntity
            {
                Id = item.Id,
                Name = item.Name
            };
        }
    }
}
