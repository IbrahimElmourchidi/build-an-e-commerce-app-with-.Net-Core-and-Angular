using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using API.Dtos;

namespace API.Controllers;

public class ProductController : BaseApiController
{
    private readonly IGenericRepository<Product> _productRepo;
    private readonly IGenericRepository<ProductType> _productTypeRepo;
    private readonly IGenericRepository<ProductBrand> _productBrandRepo;
    private readonly IMapper _mapper;
    public ProductController(IGenericRepository<Product> productRepo, IGenericRepository<ProductType> productTypeRepo, IGenericRepository<ProductBrand> productBrandRepo,
    IMapper mapper
    )
    {
        _mapper = mapper;
        _productBrandRepo = productBrandRepo;
        _productTypeRepo = productTypeRepo;
        _productRepo = productRepo;

    }
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Product>>> GetAllProducts([FromQuery] ProductSpecParams specParams)
    {
        var spec = new ProductsWithBrandAndTypeSpec(specParams);
        var products = await _productRepo.ListAllAsyncWithSpec(spec);
        return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturn>>(products));
    }

    [HttpGet("brands")]
    public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetAllBrands()
    {
        var brands = await _productBrandRepo.ListAllAsync();
        return Ok(brands);
    }

    [HttpGet("Types")]
    public async Task<ActionResult<IReadOnlyList<ProductType>>> GetAllTypes()
    {
        var types = await _productTypeRepo.ListAllAsync();
        return Ok(types);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetSingleProduct(int id)
    {
        var spec = new ProductsWithBrandAndTypeSpec(id);
        var product = await _productRepo.GetSingleWithSpec(spec);
        return Ok(product);
    }
}
