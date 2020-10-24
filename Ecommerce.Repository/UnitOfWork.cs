using Ecommerce.DatabaseContext.DatabaseContext;
using Ecommerce.Models.EntityModels;
using Ecommerce.Repository.Products;

namespace Ecommerce.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private EcommerceDatabaseContext _db;

        public UnitOfWork(EcommerceDatabaseContext db)
        {
            _db = db;
        }

        private ProductRepository _productRepository;
        private ShopRepository _shopRepository;
        private PurchesOrderRepository _purchesOrderRepository;

        public PurchesOrderRepository PurchesOrderRepository
        {
            get
            {
                if (_purchesOrderRepository == null)
                {
                    _purchesOrderRepository = new PurchesOrderRepository(_db);
                }

                return _purchesOrderRepository;
            }
        }

        ProductRepository IUnitOfWork.ProductRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_db);
                }

                return _productRepository;
            }
        }

        ShopRepository ShopRepository
        {
            get
            {
                if (_shopRepository == null)
                {
                    _shopRepository = new ShopRepository(_db);
                }

                return _shopRepository;
            }
        }

        public bool SaveChange()
        {
            return _db.SaveChanges() > 0;
        }
    }
}