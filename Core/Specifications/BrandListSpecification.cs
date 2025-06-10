using System;
using Core.Entities;

namespace Core.Specifications;

public class CategoryListSpecification : BaseSpecification<Product, string>
{
    public CategoryListSpecification()
    {
        AddSelect(x => x.Category);
        ApplyDistinct();
    }
}
