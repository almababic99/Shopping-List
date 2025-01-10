namespace Domain.DomainModels
{
    public class ShoppingListDomain
    {
        public int Id { get; set; }
        public int? ShopperId { get; set; }
        public List<ShoppingListItemDomain> Items { get; set; } = new List<ShoppingListItemDomain>();
    }
}
