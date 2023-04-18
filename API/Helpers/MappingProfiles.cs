using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos;
using AutoMapper;
using Core.Entities;

namespace Api.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Product, ProductToReturnDto>()
        .ForMember(p => p.ProductBrand, o => o.MapFrom(p => p.ProductBrand.Name))
        .ForMember(p => p.ProductType, o => o.MapFrom(p => p.ProductType.Name))
        .ForMember(p => p.PictureUrl, o => o.MapFrom<PictureUrlResolver>());

    }
}
