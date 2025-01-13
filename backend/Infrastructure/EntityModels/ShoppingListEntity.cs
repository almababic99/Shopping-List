using Infrastructure.Models;

namespace Infrastructure.EntityModels
{
    public class ShoppingListEntity
    {
        public int Id { get; set; }
        public int? ShopperId { get; set; }
        public List<ShoppingListItemEntity> Items { get; set; } = new List<ShoppingListItemEntity>();  // List of ShoppingListItem that connects ShoppingList to Item
    }
}
