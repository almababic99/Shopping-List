using Infrastructure.Models;

namespace Infrastructure.EntityModels
{
    public class ShoppingList
    {
        public int Id { get; set; }
        public int? ShopperId { get; set; }
        public List<ShoppingListItem> Items { get; set; } = new List<ShoppingListItem>();  // List of ShoppingListItem that connects ShoppingList to Item
    }
}
