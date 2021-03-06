﻿using AutoMapper;
using MyGallery.Data.Entities;
using MyGallery.ViewModels;

namespace MyGallery.Data
{
    public class DatabaseMappingProfile : Profile
    {
        public DatabaseMappingProfile()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
        }

    }
}
