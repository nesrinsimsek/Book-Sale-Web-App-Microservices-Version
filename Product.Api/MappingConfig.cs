using AutoMapper;
using Product.Entity.Concrete;
using Product.Entity.Dto;

namespace Product.Api
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Book, BookCreateDto>().ReverseMap();
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
           
    }
}
