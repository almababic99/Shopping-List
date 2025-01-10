namespace API.DTOModels
{
    public class ItemDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public int? ShopperId { get; set; }
    }
}
