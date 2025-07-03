namespace Catalog.API.Exceptions
{
    public class ProductNotFoudException : Exception
    {
        public ProductNotFoudException() : base("Product not found.")
        {
        }
    }
}
