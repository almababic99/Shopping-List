namespace API.DTOModels
{
    public class ShoppingListItemDTO
    {
        public int Id { get; set; }
        public int ShoppingListId { get; set; }  // Foreign key to ShoppingList
        public int ItemId { get; set; }  // Foreign key to Item
        public int Quantity { get; set; }  // Quantity of the item in the shopping lists   (One item can be found in maximum of 3 shopping lists.)
    }
}
