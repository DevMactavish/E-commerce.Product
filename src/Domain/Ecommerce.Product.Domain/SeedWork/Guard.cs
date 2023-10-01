namespace Ecommerce.Product.Domain.SeedWork
{
    public static class Guard
    {

        public static void That<TException>(bool condition, string message = "") where TException : System.Exception
        {
            if (condition)
                throw (TException)Activator.CreateInstance(typeof(TException), (object)message);
        }
    }
}
