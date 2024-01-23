using AutoMapper;
using BookSale.MVC.Models.Dtos;
namespace BookSale.Sale.MVC
{
    public class MappingConfig : Profile
    {
        public MappingConfig() { 

            CreateMap<BookDto, BookCreateDto>().ReverseMap();
            CreateMap<BookDto, BookUpdateDto>().ReverseMap();

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
