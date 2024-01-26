using AutoMapper;
using BookSale.Sale.Entities.Concrete;
using BookSale.Sale.Entities.Concrete.Dtos;

namespace BookSale.Sale.Api
{
    public class MappingConfig : Profile
    {
        public MappingConfig() { 

            CreateMap<Book, BookCreateDto>().ReverseMap();
            CreateMap<Book, BookDto>().ReverseMap();

            CreateMap<Order, OrderCreateDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<OrderBook, OrderBookDto>().ReverseMap();
            
            CreateMap<User, RegistrationRequestDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();

        }
    }
}
