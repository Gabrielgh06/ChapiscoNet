using System;
using Core.Entities;

namespace Core.Specifications;

public class ProductSpecification : BaseSpecification<Product>
{
    public ProductSpecification(string? category, string? size, string? sort) : base(x =>
        (string.IsNullOrEmpty(category) || x.Category == category) &&
        (string.IsNullOrEmpty(size) || x.Size == size)
    )
    {
        switch (sort) 
        {
            case "priceAsc":
                AddOrderBy(x => x.Price);
                break;
            case "priceDesc":
                AddOrderByDescending(x => x.Price);
                break;
            default:
                AddOrderBy(x => x.Name);
                break;
        }
    }
}
