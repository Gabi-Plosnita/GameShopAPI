namespace GameShop.EntityLayer.Exceptions
{
    public class GameAlreadyExistsException : Exception
    {
        public GameAlreadyExistsException()
        {
        }

        public GameAlreadyExistsException(string message)
            : base(message)
        {
        }
    }
}
