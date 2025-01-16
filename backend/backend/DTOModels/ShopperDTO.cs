namespace API.DTOModels
{
    public class ShopperDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // public List<ShoppingListDTO> ShoppingLists { get; set; } = new List<ShoppingListDTO>();  // Shopper can have multiple shopping lists
    }
}
