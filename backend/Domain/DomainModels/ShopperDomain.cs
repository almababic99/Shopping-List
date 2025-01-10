namespace Domain.DomainModels
{
    public class ShopperDomain
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ShoppingListDomain> ShoppingLists { get; set; } = new List<ShoppingListDomain>();  // Shopper can have multiple shopping lists
    }
}
