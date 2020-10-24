using Ecommerce.Repository.Products;

namespace Ecommerce.Repository
{
    public interface IUnitOfWork
    {
        ProductRepository ProductRepository { get; }
        bool SaveChange();
    }
}