using AutoMapper;
using BookSale.Sale.Entities.Concrete;
using BookSale.Sale.Entities.Concrete.Dtos;

namespace BookSale.Sale.Api
{
    public class MappingConfig : Profile
    {
        public MappingConfig() { 

            CreateMap<Book, BookCreateDto>().ReverseMap();
            CreateMap<Book, BookGetDto>().ReverseMap();
            CreateMap<Book, BookUpdateDto>().ReverseMap();

            CreateMap<Order, OrderCreateDto>().ReverseMap();
            CreateMap<Order, OrderGetDto>().ReverseMap();
            CreateMap<Order, OrderUpdateDto>().ReverseMap();

            CreateMap<Category, CategoryGetDto>().ReverseMap();
            
            CreateMap<User, RegistrationRequestDto>().ReverseMap();

        }
    }
}
