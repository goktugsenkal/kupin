using Core.Entities;

namespace Core.Interfaces;

public interface IProductRepository
{
    Task<IReadOnlyList<Product>> GetAllProductsAsync(int businessId);
    Task<Product?> GetProductByIdAsync(int businessId, int productId);
    void CreateProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(Product product);
}