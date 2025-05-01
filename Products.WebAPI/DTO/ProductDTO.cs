namespace Products.API.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PreviewDescription{ get; set; }
        public List<SellerDTO> Sellers { get; set; }
    }
}
