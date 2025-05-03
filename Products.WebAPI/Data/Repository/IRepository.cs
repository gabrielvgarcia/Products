using Products.API.Models;

namespace Products.API.Data.Repository
{
    public interface IRepository
    {
        void Add<T>(T model) where T : class;
        void Update<T>(T model) where T : class;
        void Delete<T>(T model) where T : class;
        bool Save();
        Task<Product[]> GetAllProducts();
        Task<Product> GetProductById(int productId);
        Task<Seller[]> GetAllSellers();
        Task<Seller> GetSellerById(int sellerId);
        Task<ProductSeller[]> GetAllProductsSellers();
        Task<ProductSeller> GetProductSellerById(int productSellerId);
    }
}
