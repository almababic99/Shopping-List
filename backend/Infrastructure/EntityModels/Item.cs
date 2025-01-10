namespace Infrastructure.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public int? ShopperId { get; set; }

        // lista shopping listi
        // shopping lista ima id shoppera i listu itema za svaku listu
    }
}
