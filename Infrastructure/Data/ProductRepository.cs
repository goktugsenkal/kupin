using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ProductRepository(DataContext context) : IProductRepository
{
    public async Task<IReadOnlyList<Product>> GetAllProducts(int businessId)
    {
        return await context.Product
            .Where(p => p.BusinessId == businessId)
            .ToListAsync();
    }

    public async Task<Product?> GetProductById(int businessId, int productId)
    {
        return await context.Product
            .Where(p => p.BusinessId == businessId)
            .Where(p => p.Id == productId)
            .FirstOrDefaultAsync();
    }

    public void CreateProduct(int businessId, Product product)
    {
        if (product.BusinessId != businessId)
        {
            throw new ArgumentException("business id'ler uyuşmuyor.");
        }
        context.Product.Add(product);
        context.SaveChanges();
    }

    public void UpdateProduct(int businessId, int productId, Product product)
    {
        throw new NotImplementedException();
    }

    public void DeleteProduct(int businessId, int productId)
    {
        throw new NotImplementedException();
    }
}