namespace GameShop.EntityLayer.Exceptions
{
    public class RoleDeleteException : Exception
    {
        public RoleDeleteException()
        {
        }

        public RoleDeleteException(string message)
            : base(message)
        {
        }
    }
}
