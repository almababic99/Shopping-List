namespace API.DTOModels
{
    public class ItemDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public List<ShoppingListItemDTO> ShoppingLists { get; set; } = new List<ShoppingListItemDTO>();  // Item can be in multiple shopping lists
    }
}
