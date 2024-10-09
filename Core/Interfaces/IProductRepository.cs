using Core.Entities;
using Core.Helpers;

namespace Core.Interfaces;

public interface IProductRepository
{
    Task<PagedList<Product>> GetAllProductsAsync
        (int businessId, int pageIndex, int pageSize);
    Task<Product?> GetProductByIdAsync(int businessId, int productId);
    void CreateProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(Product product);
}