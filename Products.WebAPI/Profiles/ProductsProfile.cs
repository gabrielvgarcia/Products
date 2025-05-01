using AutoMapper;
using Products.API.DTO;
using Products.API.Models;

namespace Products.API.Profiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(
                    p => p.PreviewDescription,
                    o => o.MapFrom(src => $"{src.Name} - {src.Description}")
                )
                .ForMember
                (
                    p => p.Sellers,
                    o => o.MapFrom(src => src.ProductSellers.Select(x => x.Seller))
                );

            CreateMap<Seller, SellerDTO>().ReverseMap();

            CreateMap<ProductSeller, ProductSellerDTO>().ReverseMap();

            CreateMap<Product, RegisterProductDTO>().ReverseMap();
            CreateMap<Seller, RegisterSellerDTO>().ReverseMap();
            CreateMap<ProductSeller, RegisterProductSellerDTO>().ReverseMap();
        }
    }
}
