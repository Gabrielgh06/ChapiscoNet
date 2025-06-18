using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class CreateProductDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    [Range(0.01, double.MaxValue, ErrorMessage = "Preço deve ser maior do que 0")]
    public decimal Price { get; set; }
    [Required]
    public string Size { get; set; } = string.Empty;
    [Required]
    public string Category { get; set; } = string.Empty;
    [Range(1, int.MaxValue, ErrorMessage = "Quantidade no estoque deve ser no mínimo 1")]
    public int QuantityInStock { get; set; }

    [MinLength(1, ErrorMessage = "O produto deve ter pelo menos uma imagem.")]
    public List<string> ImagesUrl { get; set; } = new();
    
}