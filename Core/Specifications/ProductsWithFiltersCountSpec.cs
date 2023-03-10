using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications;

public class ProductsWithFiltersCountSpec : BaseSpecification<Product>
{
    public ProductsWithFiltersCountSpec(ProductSpecParams specParams) : base(
        x =>
        (string.IsNullOrEmpty(specParams.Search) || x.Name.ToLower().Contains(specParams.Search))
        &&
        (!specParams.BrandId.HasValue || x.ProductBrandId == specParams.BrandId)
        &&
        (!specParams.TypeId.HasValue || x.ProductTypeId == specParams.TypeId)
    )
    {
    }
}
