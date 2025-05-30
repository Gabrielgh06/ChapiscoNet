using System;
using Core.Entities;

namespace Core.Interfaces;

public interface IProductsRepository
{
    Task<IReadOnlyList<Product>> GetProductsAsync(string? category, string? size, string? sort);
    Task<Product?> GetProductByIdAsync(int id);
    Task<IReadOnlyList<string>> GetCategoryAsync();
    Task<IReadOnlyList<string>> GetSizeAsync();

    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(Product product);
    bool ProductExists(int id);
    Task<bool> SaveChangesAsync();
}
