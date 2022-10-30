using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Dtos.Product;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<ProductModel, ProductDto>()
            .ReverseMap();
            CreateMap<ProductModel, ProductDtoCreate>()
            .ReverseMap();
            CreateMap<ProductModel, ProductDtoUpdate>()
            .ReverseMap();
        }
    }
}
