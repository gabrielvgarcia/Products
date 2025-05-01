namespace Products.API.Models
{
    public class ProductSeller
    {
        public ProductSeller() { }
        public ProductSeller(int id, int productId, int sellerId, decimal price, int stockQuantity, string sku)
        {
            Id = id;
            ProductId = productId;
            SellerId = sellerId;
            Price = price;
            StockQuantity = stockQuantity;
            Sku = sku;
        }

        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string Sku { get; set; } = string.Empty;
    }
}
