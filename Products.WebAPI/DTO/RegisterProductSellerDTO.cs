namespace Products.API.DTO
{
    public class RegisterProductSellerDTO
    {
        public int ProductId { get; set; }
        public int SellerId { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string Sku { get; set; } = string.Empty;
    }
}
