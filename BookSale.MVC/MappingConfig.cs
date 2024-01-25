using AutoMapper;
using BookSale.MVC.Models.Dtos;
using BookSale.Sale.Entities.Concrete;
namespace BookSale.Sale.MVC
{
    public class MappingConfig : Profile
    {
        public MappingConfig() { 

            CreateMap<BookDto, BookCreateDto>().ReverseMap();
            CreateMap<BookDto, BookUpdateDto>().ReverseMap();
            CreateMap<BookDto, Book>().ReverseMap();

            CreateMap<OrderDto, OrderCreateDto>().ReverseMap();
            CreateMap<OrderDto, OrderUpdateDto>().ReverseMap();

            //CreateMap<Book, BookUpdateDto>().ReverseMap();

            //CreateMap<Order, OrderCreateDto>().ReverseMap();
            //CreateMap<Order, OrderGetDto>().ReverseMap();
            //CreateMap<Order, OrderUpdateDto>().ReverseMap();

            //CreateMap<Category, CategoryGetDto>().ReverseMap();
            
            //CreateMap<User, RegistrationRequestDto>().ReverseMap();

        }
    }
}
