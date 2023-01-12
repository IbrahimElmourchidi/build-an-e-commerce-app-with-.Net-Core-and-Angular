using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using Core.Specifications;
using AutoMapper;
using API.Dtos;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

        public ProductController(IGenericRepository<Product> productRepo, IGenericRepository<ProductType> productTypeRepo, IGenericRepository<ProductBrand> productBrandRepo, IMapper mapper)
        {
            this._mapper = mapper;
            this._productTypeRepo = productTypeRepo;
            this._productBrandRepo = productBrandRepo;
            this._productRepo = productRepo;

        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> getAllProuducts()
        {
            var spec = new ProductsWithTypesAndBrandSpecification();
            var products = await this._productRepo.ListAsync(spec);
            return Ok(_mapper
            .Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
        }

        [HttpGet]
        [Route("brands")]
        public async Task<ActionResult<List<ProductBrand>>> getAllBrands()
        {
            var brands = await this._productBrandRepo.GetAllAsycn();
            return Ok(brands);
        }


        [HttpGet]
        [Route("types")]
        public async Task<ActionResult<List<ProductType>>> getAlltypes()
        {
            var types = await this._productTypeRepo.GetAllAsycn();
            return Ok(types);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> getSingleProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandSpecification(id);
            var product = await this._productRepo.GetEntityWithSpec(spec);
            if (product == null) return NotFound("Not found");
            return _mapper.Map<Product, ProductToReturnDto>(product);
        }
    }
}