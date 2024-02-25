using AutoMapper;
using OrderEntity.Dtos;
using OrderEntity.Entities;

namespace OrderApi
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Order, OrderCreateDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
        }
    }
}
