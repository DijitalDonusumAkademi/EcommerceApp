using Ecommerce.Models.EntityModels;

namespace Ecommerce.BLL.Abstraction
{
    public interface IShopManager:IManager<Shop>
    {
        void LoadProduct(Shop shop);
    }
}