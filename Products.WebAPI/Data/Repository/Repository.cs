using Microsoft.EntityFrameworkCore;
using Products.API.Models;

namespace Products.API.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _dbContext;

        public Repository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public void Add<T>(T model) where T : class
        {
            _dbContext.Add(model);
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() > 0;
        }
        public void Delete<T>(T model) where T : class
        {
            _dbContext.Remove(model);
        }

        public void Update<T>(T entity) where T : class
        {
            _dbContext.Update(entity);
        }

        public Product[] GetAllProducts()
        {
            IQueryable<Product> productsQuery = _dbContext.Product;

            productsQuery = productsQuery.Include(p => p.ProductSellers)
                                         .ThenInclude(p => p.Seller)
                                         .AsNoTracking()
                                         .OrderBy(p => p.Id);

            return [.. productsQuery];
        }
        public Product GetProductById(int productId)
        {
            IQueryable<Product> productsQuery = _dbContext.Product;

            productsQuery = productsQuery.Include(p => p.ProductSellers).ThenInclude(p => p.Seller).AsNoTracking().OrderBy(a => a.Id);

            return productsQuery.FirstOrDefault(p => p.Id == productId);
        }

        public Seller[] GetAllSellers()
        {
            IQueryable<Seller> sellersQuery = _dbContext.Seller;

            sellersQuery = sellersQuery.Include(s => s.ProductSellers)
                                       .ThenInclude(s => s.Product)
                                       .AsNoTracking()
                                       .OrderBy(s => s.Id);

            return [.. sellersQuery];
        }

        public Seller GetSellerById(int sellerId)
        {
            IQueryable<Seller> sellersQuery = _dbContext.Seller;

            sellersQuery = sellersQuery.Include(s => s.ProductSellers).ThenInclude(s => s.Product).AsNoTracking().OrderBy(a => a.Id);

            return sellersQuery.FirstOrDefault(s => s.Id == sellerId);
        }

        public ProductSeller[] GetAllProductsSellers()
        {
            IQueryable<ProductSeller> productSellerQuery = _dbContext.ProductSeller;

            productSellerQuery = productSellerQuery.Include(ps => ps.Seller)
                                       .Include(ps => ps.Product)
                                       .AsNoTracking()
                                       .OrderBy(ps => ps.Id);

            return [.. productSellerQuery];
        }

        public ProductSeller GetProductSellerById(int productSellerId)
        {
            IQueryable<ProductSeller> productSellerQuery = _dbContext.ProductSeller;

            productSellerQuery = productSellerQuery.Include(ps => ps.Seller).Include(ps => ps.Product).AsNoTracking().OrderBy(ps => ps.Id);

            return productSellerQuery.FirstOrDefault(s => s.Id == productSellerId);
        }
    }
}
