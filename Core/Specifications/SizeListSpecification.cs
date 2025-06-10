using System;
using Core.Entities;

namespace Core.Specifications;

public class SizeListSpecification : BaseSpecification<Product, string>
{
    public SizeListSpecification()
    {
        AddSelect(x => x.Size);
        ApplyDistinct();
    }
}
