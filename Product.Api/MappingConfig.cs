﻿using AutoMapper;
using Product.Entity.Dto;
using Product.Entity.Entities;

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