namespace Products.API.DTO
{
    public class SellerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductSellerDto> Products { get; set; }
    }

}
