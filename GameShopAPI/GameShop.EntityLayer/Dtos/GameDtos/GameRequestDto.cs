namespace GameShop.EntityLayer.Dtos
{
    public class GameRequestDto
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public int GameCompanyId { get; set; }

        public int CategoryId { get; set; }
    }
}
