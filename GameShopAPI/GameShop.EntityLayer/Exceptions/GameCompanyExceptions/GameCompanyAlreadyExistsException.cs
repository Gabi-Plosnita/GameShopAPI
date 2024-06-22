namespace GameShop.EntityLayer.Exceptions
{
    public class GameCompanyAlreadyExistsException : Exception
    {
        public GameCompanyAlreadyExistsException()
        {
        }

        public GameCompanyAlreadyExistsException(string message)
            : base(message)
        {
        }
    }
}
