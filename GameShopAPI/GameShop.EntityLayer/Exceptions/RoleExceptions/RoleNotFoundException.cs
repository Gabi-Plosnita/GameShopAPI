namespace GameShop.EntityLayer.Exceptions
{
    public class RoleNotFoundException : Exception
    {
        public RoleNotFoundException()
        {
        }

        public RoleNotFoundException(string message)
            : base(message)
        {
        }
    }
}
