namespace GameShop.EntityLayer.Exceptions
{
    public class GameCompanyNotFoundException : Exception
    {
        public GameCompanyNotFoundException()
        {
        }

        public GameCompanyNotFoundException(string message)
            : base(message)
        {
        }
    }
}
