using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications;

public class ProductsWithBrandAndTypeSpec : BaseSpecification<Product>
{
    public ProductsWithBrandAndTypeSpec()
    {
        AddInclude(x => x.ProductBrand);
        AddInclude(x => x.ProductType);
    }

    public ProductsWithBrandAndTypeSpec(int id) : base(x => x.Id == id)
    {
        AddInclude(x => x.ProductBrand);
        AddInclude(x => x.ProductType);
    }
}
