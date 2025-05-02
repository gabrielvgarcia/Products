using Products.API.Models;

namespace Products.API.Data.Repository
{
    public interface IRepository
    {
        void Add<T>(T model) where T : class;
        void Update<T>(T model) where T : class;
        void Delete<T>(T model) where T : class;
        bool Save();
        Product[] GetAllProducts();
        Product GetProductById(int productId);
        Seller[] GetAllSellers();
        Seller GetSellerById(int sellerId);
        ProductSeller[] GetAllProductsSellers();
        ProductSeller GetProductSellerById(int productSellerId);
    }
}
