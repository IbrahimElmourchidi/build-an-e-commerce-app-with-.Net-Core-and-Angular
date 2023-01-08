using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;

        public ProductsController(IGenericRepository<Product> productRepo, IGenericRepository<ProductType> productTypeRepo, IGenericRepository<ProductBrand> productBrandRepo)
        {
            this._productTypeRepo = productTypeRepo;
            this._productBrandRepo = productBrandRepo;
            this._productRepo = productRepo;

        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> getAllProuducts()
        {
            var products = await this._productRepo.GetAllAsycn();
            return Ok(products);
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
        public async Task<ActionResult<Product>> getSingleProduct(int id)
        {
            var product = await this._productRepo.GetByIdAsync(id);
            if (product == null) return NotFound("Not found");
            return Ok(product);
        }
    }
}