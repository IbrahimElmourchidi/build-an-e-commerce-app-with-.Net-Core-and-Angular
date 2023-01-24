using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers;

public class PictureUrlResolver : IValueResolver<Product, ProductToReturn, string>
{
    private readonly IConfiguration _config;
    public PictureUrlResolver(IConfiguration config)
    {
        _config = config;
    }

    public string Resolve(Product source, ProductToReturn destination, string destMember, ResolutionContext context)
    {
        if (source.PictureUrl != null)
        {
            return _config["ApiUrl"] + source.PictureUrl;
        }
        return null;
    }
}
