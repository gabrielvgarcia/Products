namespace Products.API.Models
{
    public class Seller
    {
        public Seller(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<ProductSeller> ProductSellers { get; set; } = new List<ProductSeller>();
    }
}
