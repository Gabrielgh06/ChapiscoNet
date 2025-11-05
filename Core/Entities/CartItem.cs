using System;

namespace Core.Entities;

public class CartItem
{
    public int ProductId { get; set; }
    public required string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public required string ImagesUrl { get; set; }
    public required string Size { get; set; }
    public required string Category { get; set; }
}
