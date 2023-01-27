using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Specifications;

namespace API.Helpers;

public class Pagination<T> where T : class
{

    public Pagination()
    {
    }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public int Count { get; set; }
    public IReadOnlyList<T> Data { get; set; }
    public string FirstPage { get; set; }
    public string PreviousLink { get; set; }
    public string NextLink { get; set; }
    public string LastPage { get; set; }

    public void ApplyNavigationLinks(string baseUrl, ProductSpecParams specParams)
    {

        var totalPages = Math.Ceiling((double)Count / PageSize);
        if (specParams.Sort != null)
        {
            baseUrl += $"sort={specParams.Sort}&";
        }
        if (specParams.BrandId != null)
        {
            baseUrl += $"brandId={specParams.BrandId}&";
        }

        if (specParams.TypeId != null)
        {
            baseUrl += $"typeId={specParams.TypeId}&";
        }

        FirstPage = baseUrl + $"pageIndex=1&pageSize={PageSize}";
        NextLink = (PageIndex == totalPages) ? null : baseUrl + $"pageIndex={PageIndex + 1}&pageSize={PageSize}";
        PreviousLink = (PageIndex == 1) ? null : baseUrl + $"pageIndex={PageIndex - 1}&pageSize={PageSize}";
        LastPage = baseUrl + $"pageIndex={totalPages}&pageSize={PageSize}";
    }
}
