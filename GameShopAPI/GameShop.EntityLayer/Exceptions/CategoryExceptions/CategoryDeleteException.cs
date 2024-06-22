namespace GameShop.EntityLayer.Exceptions
{
    public class CategoryDeleteException : Exception
    {
        public CategoryDeleteException()
        {
        }

        public CategoryDeleteException(string message)
            : base(message)
        {
        }
    }  
}
