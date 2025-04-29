using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ICatalogContext _context;

    public ProductRepository(ICatalogContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        throw new NotImplementedException();
    }

    public async Task<Product> GetProductById(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Product>> GetProductsByCategory(string category)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Product>> GetProductByName(string name)
    {
        throw new NotImplementedException();
    }

    public async Task CreateProduct(Product product)
    {
        await _context.Products.InsertOneAsync(product);
    }

    public async Task<bool> UpdateProduct(Product product)
    {
        FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, product.Id);
        var update = Builders<Product>.Update
            .Set(product => product.Name, product.Name)
            .Set(product => product.Description, product.Description)
            .Set(product => product.Price, product.Price)
            .Set(product => product.Category, product.Category);
        
        var updateResult = await _context.Products.UpdateOneAsync(filter, update);

        return updateResult.IsAcknowledged;
    }

    public async Task<bool> DeleteProduct(string id)
    {
        FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, id);
        
        DeleteResult deleteResult = await _context.Products.DeleteOneAsync(filter);
        
        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }
}