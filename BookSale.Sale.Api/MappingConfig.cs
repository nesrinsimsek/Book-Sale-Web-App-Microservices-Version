using AutoMapper;
using BookSale.Sale.Entities.Concrete;
using BookSale.Sale.Entities.Concrete.Dtos;

namespace BookSale.Sale.Api
{
    public class MappingConfig : Profile
    {
        public MappingConfig() { 
        
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Book, BookCreateDto>().ReverseMap();
            CreateMap<Book, BookGetDto>().ReverseMap();
            CreateMap<Category, CategoryGetDto>().ReverseMap();

        }
    }
}
