namespace Products.API.Models
{
    public class ProductSeller
    {
        public ProductSeller(int productId, Product product, int sellerId, Seller seller, decimal price, int stockQuantity, string sku)
        {
            ProductId = productId;
            Product = product;
            SellerId = sellerId;
            Seller = seller;
            Price = price;
            StockQuantity = stockQuantity;
            Sku = sku;
        }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string Sku { get; set; } = string.Empty;
    }
}
