using Infrastructure.EntityModels;

namespace Infrastructure.Models
{
    public class Shopper
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ShoppingList> ShoppingLists { get; set; } = new List<ShoppingList>();  // Shopper can have multiple shopping lists
    }
}
