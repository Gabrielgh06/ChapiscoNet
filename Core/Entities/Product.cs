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
    public List<string> PictureUrl { get; set; } = new(); // Lista de URLs de imagens

    // Propriedade para acessar a imagem principal (obrigatória)
    public string ImagemPrincipalUrl
    {
        get => PictureUrl.Count > 0 ? PictureUrl[0] : throw new InvalidOperationException("Produto deve ter pelo menos uma imagem.");
        set
        {
            if (PictureUrl.Count == 0)
                PictureUrl.Add(value);
            else
                PictureUrl[0] = value;
        }
    }
}
