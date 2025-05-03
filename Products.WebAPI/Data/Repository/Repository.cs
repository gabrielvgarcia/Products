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

        public async Task<Product[]> GetAllProducts()
        {
            IQueryable<Product> productsQuery = _dbContext.Product;

            productsQuery = productsQuery.Include(p => p.ProductSellers)
                                         .ThenInclude(p => p.Seller)
                                         .AsNoTracking()
                                         .OrderBy(p => p.Id);

            return await productsQuery.ToArrayAsync();
        }
        public async Task<Product> GetProductById(int productId)
        {
            IQueryable<Product> productsQuery = _dbContext.Product;

            productsQuery = productsQuery.Include(p => p.ProductSellers).ThenInclude(p => p.Seller).AsNoTracking().OrderBy(a => a.Id);

            return await productsQuery.FirstOrDefaultAsync(p => p.Id == productId);
        }

        public async Task<Seller[]> GetAllSellers()
        {
            IQueryable<Seller> sellersQuery = _dbContext.Seller;

            sellersQuery = sellersQuery.Include(s => s.ProductSellers)
                                       .ThenInclude(s => s.Product)
                                       .AsNoTracking()
                                       .OrderBy(s => s.Id);

            return await sellersQuery.ToArrayAsync();
        }

        public async Task<Seller> GetSellerById(int sellerId)
        {
            IQueryable<Seller> sellersQuery = _dbContext.Seller;

            sellersQuery = sellersQuery.Include(s => s.ProductSellers).ThenInclude(s => s.Product).AsNoTracking().OrderBy(a => a.Id);

            return await sellersQuery.FirstOrDefaultAsync(s => s.Id == sellerId);
        }

        public async Task<ProductSeller[]> GetAllProductsSellers()
        {
            IQueryable<ProductSeller> productSellerQuery = _dbContext.ProductSeller;

            productSellerQuery = productSellerQuery.Include(ps => ps.Seller)
                                       .Include(ps => ps.Product)
                                       .AsNoTracking()
                                       .OrderBy(ps => ps.Id);

            return await productSellerQuery.ToArrayAsync();
        }

        public async Task<ProductSeller> GetProductSellerById(int productSellerId)
        {
            IQueryable<ProductSeller> productSellerQuery = _dbContext.ProductSeller;

            productSellerQuery = productSellerQuery.Include(ps => ps.Seller).Include(ps => ps.Product).AsNoTracking().OrderBy(ps => ps.Id);

            return await productSellerQuery.FirstOrDefaultAsync(s => s.Id == productSellerId);
        }
    }
}
