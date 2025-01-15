using Infrastructure.Models;

namespace Infrastructure.EntityModels
{
    public class ShoppingListItemEntity
    {
        public int Id { get; set; }
        public int ShoppingListId { get; set; }  // Foreign key to ShoppingList
        public required ShoppingListEntity ShoppingList { get; set; }  // Navigation property
        public int ItemId { get; set; }  // Foreign key to Item
        public ItemEntity? Item { get; set; }  // Navigation property

        // public int Quantity { get; set; }  // Quantity of the item in the shopping lists   (One item can be found in maximum of 3 shopping lists.)
    }
}

// ShoppingListItem represents the relationship between a shopping list and an item
