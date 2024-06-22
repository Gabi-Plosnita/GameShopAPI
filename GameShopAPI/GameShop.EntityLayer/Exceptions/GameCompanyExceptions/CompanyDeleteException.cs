namespace GameShop.EntityLayer.Exceptions
{
    public class CompanyDeleteException : Exception
    {
        public CompanyDeleteException()
        {
        }

        public CompanyDeleteException(string message)
            : base(message)
        {
        }
    }
}
