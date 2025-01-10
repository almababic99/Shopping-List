namespace API.DTOModels
{
    public class ShoppingListDTO
    {
        public int Id { get; set; }
        public int? ShopperId { get; set; }
        public List<ShoppingListItemDTO> Items { get; set; } = new List<ShoppingListItemDTO>();  
    }
}
