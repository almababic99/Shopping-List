namespace API.DTOModels
{
    public class ShoppingListItemDTO
    {
        public int Id { get; set; }
        public ItemDTO? Item { get; set; }  // Item details

        // public int Quantity { get; set; }  // Quantity of the item in the shopping lists   (One item can be found in maximum of 3 shopping lists.)
    }
}
