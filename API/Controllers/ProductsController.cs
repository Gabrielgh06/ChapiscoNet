using System;
using API.RequestHelpers;
using Core.Entities;
using Core.Specifications;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IGenericRepository<Product> repo) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts([FromQuery]ProductSpecParams specParams)
    {
        var spec = new ProductSpecification(specParams);

        return await CreatePageResult(repo, spec, specParams.PageIndex, specParams.PageSize);
    }

    [HttpGet("{id:int}")] // api/products/1
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await repo.GetByIdAsync(id);

        if (product == null) return NotFound();

        return product;
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        repo.Add(product);

        if (await repo.SaveAllAsync())
        {
            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        return BadRequest("Não foi possível criar o produto");
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateProduct(int id, Product product)
    {
        if (id != product.Id || !ProductExists(id)) return BadRequest("Cannot update product");

        repo.Update(product);

        if (await repo.SaveAllAsync())
        {
            return NoContent();
        }
        
        return BadRequest("Não foi possível atualizar o produto");
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        var product = await repo.GetByIdAsync(id);

        if (product == null) return NotFound();

        repo.Remove(product);

        if (await repo.SaveAllAsync())
        {
            return NoContent();
        }
        
        return BadRequest("Não foi possível deletar o produto");
    }

    [HttpGet("categories")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetCategories()
    {
        var spec = new CategoryListSpecification();
        return Ok(await repo.ListAsync(spec));
    }

    [HttpGet("sizes")]
    public async Task<ActionResult<IReadOnlyList<string>>> Getsizes()
    {
        var spec = new SizeListSpecification();
        return Ok(await repo.ListAsync(spec));
    }
    
    private bool ProductExists(int id)
    {
        return repo.Exists(id);
    }
}