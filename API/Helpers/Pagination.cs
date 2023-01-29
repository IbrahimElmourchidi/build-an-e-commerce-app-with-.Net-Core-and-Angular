using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Specifications;

namespace API.Helpers;

public class Pagination<T> where T : class
{

    private ProductSpecParams SpecParams { get; }

    public Pagination(ProductSpecParams specParams)
    {
        SpecParams = specParams;
        PageSize = specParams.PageSize;
        PageIndex = specParams.PageIndex;
    }

    public int PageSize { get; private set; }
    public int PageIndex { get; private set; }
    public int Count { get; set; }
    public IReadOnlyList<T> Data { get; set; }
    public string? BaseUrl
    {
        set => ApplyNavigationLinks(value, SpecParams);
    }
    public string? FirstPageLink { get; private set; }
    public string? PreviousPageLink { get; private set; }
    public string? NextPageLink { get; private set; }
    public string? LastPageLink { get; private set; }
    private void ApplyNavigationLinks(string baseUrl, ProductSpecParams specParams)
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

        FirstPageLink = baseUrl + $"pageIndex=1&pageSize={PageSize}";
        NextPageLink = (PageIndex == totalPages) ? null : baseUrl + $"pageIndex={PageIndex + 1}&pageSize={PageSize}";
        PreviousPageLink = (PageIndex == 1) ? null : baseUrl + $"pageIndex={PageIndex - 1}&pageSize={PageSize}";
        LastPageLink = baseUrl + $"pageIndex={totalPages}&pageSize={PageSize}";
    }
}
