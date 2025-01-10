namespace Domain.DomainModels
{
    public class ItemDomain
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public List<ShoppingListItemDomain> ShoppingLists { get; set; } = new List<ShoppingListItemDomain>();  // Item can be in multiple shopping lists
    }
}
