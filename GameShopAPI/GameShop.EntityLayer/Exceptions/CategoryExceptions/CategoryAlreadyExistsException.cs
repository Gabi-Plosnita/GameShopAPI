namespace GameShop.EntityLayer.Exceptions
{
    public class CategoryAlreadyExistsException : Exception
    {
        public CategoryAlreadyExistsException()
        {
        }

        public CategoryAlreadyExistsException(string message)
            : base(message)
        {
        }
    }
}
