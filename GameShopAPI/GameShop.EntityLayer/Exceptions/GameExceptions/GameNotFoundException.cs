namespace GameShop.EntityLayer.Exceptions
{
    public class GameNotFoundException : Exception
    {
        public GameNotFoundException()
        {
        }

        public GameNotFoundException(string message)
            : base(message)
        {
        }
    }
}
