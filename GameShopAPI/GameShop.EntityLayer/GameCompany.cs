namespace GameShop.EntityLayer
{
    public class GameCompany
    {
        public int GameCompanyId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public List<Game> Games { get; set; }
    }
}
