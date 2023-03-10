using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

public class Product : BaseEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string PictureUrl { get; set; }
    public decimal Price { get; set; }
    public  ProductBrand? ProductBrand { get; set; }
    public int ProductBrandId { get; set; }
    public  ProductType? ProductType { get; set; }
    public int ProductTypeId { get; set; }
}
