namespace Domain.DomainModels
{
    public class ItemDomain
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public int? ShopperId { get; set; }
    }
}
