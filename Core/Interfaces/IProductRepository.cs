using Core.Entities;

namespace Core.Interfaces;

public interface IProductRepository
{
    Task<IReadOnlyList<Product>> GetAllProducts(int businessId);
    Task<Product?> GetProductById(int businessId, int productId);
    void CreateProduct(Product product);
    void UpdateProduct(int businessId, int productId, Product product);
    void DeleteProduct(int businessId, int productId);
}