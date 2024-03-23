using AutoMapper;
using BookSale.MVC.Models.Dtos;
using Product.Entity.Entities;
namespace BookSale.Sale.MVC
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<BookDto, Book>().ReverseMap();
        }
    }
}
