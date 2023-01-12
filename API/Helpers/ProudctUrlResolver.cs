using System;
using Core.Entities;
using AutoMapper;
using API.Dtos;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class ProudctUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration _config;
        public ProudctUrlResolver(IConfiguration config)
        {
            this._config = config;
        }

        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!(string.IsNullOrEmpty(source.PictureUrl)))
            {
                return _config["ApiUrl"] + source.PictureUrl;
            }

            return null;
        }
    }
}