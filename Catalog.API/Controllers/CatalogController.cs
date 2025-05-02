using Catalog.API.Entities;
using Catalog.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

[Route("api/v1/[controller]")] 
public class CatalogController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public CatalogController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        var products = await _productRepository.GetProducts();
        
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProductById(string id)
    {
        var productId = await _productRepository.GetProductById(id);

        if (productId == null) return NotFound();
        
        return Ok(productId);
    }

    [HttpGet("category")]
    public async Task<ActionResult<Product>> GetProductByCategory(string category)
    {
        var productCategory = await _productRepository.GetProductsByCategory(category);
        
        if (productCategory == null) return BadRequest("Invalid category");

        return Ok(productCategory);
    }

    [HttpGet("name")]
    public async Task<ActionResult<Product>>? GetProductByName(string name)
    {
        var productName = await _productRepository.GetProductByName(name);
        
        if (productName == null) return NotFound();
        
        return Ok(productName);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
    {
        await _productRepository.CreateProduct(product);
        
        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult<Product>> UpdateProduct([FromBody] Product product)
    {
        if (product == null) return BadRequest("Invalid product.");
        
        var productIsUpdated = await _productRepository.UpdateProduct(product);
        
        return Ok(productIsUpdated);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Product>> DeleteProduct(string id)
    {
        var productIsDeleted = await _productRepository.DeleteProduct(id);
        
        if (productIsDeleted) return NoContent();
        
        return Ok(productIsDeleted);
    }
}