namespace Products.API.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ProductSellerDto> Sellers { get; set; }
    }

}
