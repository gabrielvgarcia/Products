namespace Products.API.Models
{
    public class Product
    {
        public Product(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<ProductSeller> ProductSellers { get; set; } = new List<ProductSeller>();
    }
}
