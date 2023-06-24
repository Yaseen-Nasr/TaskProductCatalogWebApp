using AutoMapper;

namespace ProductCatalog.Web.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Products 
            CreateMap<Product, ProductViewModel>()
                          .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category!.Name)) ;
            CreateMap<Product, ProductShortInfoViewModel>()
                          .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category!.Name)) ;

            CreateMap<ProductFormViewModel, Product>()
                .ReverseMap()
                .ForMember(dest => dest.Categories, opt => opt.Ignore());

            //categories 
            CreateMap<Category, SelectListItem>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Name));

        }
    }
}
