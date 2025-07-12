using BuildingBlocks.Exceptions;

namespace Catalog.API.Exceptions
{
    public class ProductNotFoudException : NotFoundException
    {
        public ProductNotFoudException(Guid Id) : base("Product", Id)
        {
        }
    }
}
