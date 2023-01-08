using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {

        private readonly StoreContext _context;

        public ProductRepository(StoreContext context)
        {
            this._context = context;

        }

        public async Task<IReadOnlyList<Product>> GetAllProductsAsync()
        {
            return await this._context.Products
                .Include(p => p.ProductBrand)
                .Include(p => p.ProductType)
                .ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await this._context.Products
            .Include(p => p.ProductBrand)
            .Include(p => p.ProductType)
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        async Task<IReadOnlyList<ProductBrand>> IProductRepository.GetProductBrandsAsync()
        {
            return await this._context.ProductBrands.ToListAsync();
        }

        async Task<IReadOnlyList<ProductType>> IProductRepository.GetProductTypesAsync()
        {
            return await this._context.ProductTypes.ToListAsync();
        }
    }
}