using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications;

public class ProductsWithBrandAndTypeSpec : BaseSpecification<Product>
{
    public ProductsWithBrandAndTypeSpec(ProductSpecParams specParams) : base(
        x =>
        (string.IsNullOrEmpty(specParams.Search) || x.Name.ToLower().Contains(specParams.Search))
        &&
        (!specParams.BrandId.HasValue || x.ProductBrandId == specParams.BrandId)
        &&
        (!specParams.TypeId.HasValue || x.ProductTypeId == specParams.TypeId)
    )
    {
        AddInclude(x => x.ProductBrand);
        AddInclude(x => x.ProductType);
        ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
        if (!string.IsNullOrEmpty(specParams.Sort))
        {
            switch (specParams.Sort)
            {
                case "priceAsc":
                    AddOrderBy(p => p.Price);
                    break;
                case "priceDesc":
                    AddOrderByDescending(p => p.Price);
                    break;
                default:
                    AddOrderBy(p => p.Name);
                    break;
            }
        }
    }

    public ProductsWithBrandAndTypeSpec(int id) : base(x => x.Id == id)
    {
        AddInclude(x => x.ProductBrand);
        AddInclude(x => x.ProductType);
    }
}
