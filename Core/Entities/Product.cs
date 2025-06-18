using System;

namespace Core.Entities;

public class Product : BaseEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
    public required string Size { get; set; }
    public required string Category { get; set; }
    public int QuantityInStock { get; set; }
    public List<string> ImagesUrl { get; set; } = new(); // Lista de URLs de imagens

    // Propriedade para acessar a imagem principal (obrigatória)
    public string ImagemPrincipalUrl
    {
        get => ImagesUrl.Count > 0 ? ImagesUrl[0] : throw new InvalidOperationException("Produto deve ter pelo menos uma imagem.");
        set
        {
            if (ImagesUrl.Count == 0)
                ImagesUrl.Add(value);
            else
                ImagesUrl[0] = value;
        }
    }
}
