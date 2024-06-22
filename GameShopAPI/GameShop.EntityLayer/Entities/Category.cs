namespace GameShop.EntityLayer.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public List<Game> Games { get; set; }
    }
}
