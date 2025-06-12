using System;

namespace Core.Specifications;

public class ProductSpecParams
{
    private const int MaxPageSize = 50;
    public int PageIndex { get; set; } = 1;

    private int _pageSize = 6;
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }


    private List<string> _categories = [];
    public List<string> Categories
    {
        get => _categories;
        set
        {
            _categories = value.SelectMany(x => x.Split(',', StringSplitOptions.RemoveEmptyEntries)).ToList();
        }
    }

    private List<string> _sizes = [];
    public List<string> Sizes
    {
        get => _sizes;
        set
        {
            _sizes = value.SelectMany(x => x.Split(',', StringSplitOptions.RemoveEmptyEntries)).ToList();
        }
    }

    public string? Sort { get; set; }
    
    private string? _search;
    public string Search
    {
        get => _search ?? "";
        set => _search = value.ToLower();
    }
    
    
}
