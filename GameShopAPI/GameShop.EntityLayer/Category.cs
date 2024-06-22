namespace GameShop.EntityLayer
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public List<Game> Games { get; set; }
    }
}
