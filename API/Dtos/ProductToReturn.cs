using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;

public class ProductToReturn
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string PictureUrl { get; set; }
    public decimal Price { get; set; }
    public required string ProductBrand { get; set; }
    public required string ProductType { get; set; }
}
