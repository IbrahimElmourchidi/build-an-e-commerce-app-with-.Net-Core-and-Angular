using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandSpecification()
        {
            AddInculde(x => x.ProductType);
            AddInculde(x => x.ProductBrand);
        }

        public ProductsWithTypesAndBrandSpecification(int id) : base(x => x.Id == id)
        {
            AddInculde(x => x.ProductType);
            AddInculde(x => x.ProductBrand);
        }
    }
}