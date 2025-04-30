namespace Products.API.Models
{
    public class Seller
    {
        public Seller(int id, string name, ICollection<ProductSeller> productSellers)
        {
            Id = id;
            Name = name;
            ProductSellers = productSellers;
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<ProductSeller> ProductSellers { get; set; } = new List<ProductSeller>();
    }
}
