using Catalog.API.Entities;

namespace Catalog.API.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProducts();
    Task<Product> GetProductById(string id);
    Task<IEnumerable<Product>> GetProductsByCategory(string category);
    Task<IEnumerable<Product>> GetProductByName(string name);
    
    Task CreateProduct(Product product);
    Task<bool> UpdateProduct(Product product);   
    Task<bool> DeleteProduct(string id); 
}