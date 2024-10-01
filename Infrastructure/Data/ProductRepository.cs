using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ProductRepository(DataContext context) : IProductRepository
{
    public async Task<IReadOnlyList<Product>> GetAllProductsAsync(int businessId)
    {
        return await context.Product
            .Where(p => p.BusinessId == businessId)
            .ToListAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int businessId, int productId)
    {
        return await context.Product
            .Where(p => p.BusinessId == businessId)
            .Where(p => p.Id == productId)
            .FirstOrDefaultAsync();
    }

    public void CreateProduct(Product product)
    {
        context.Product.Add(product);
        context.SaveChanges();
    }

    public void UpdateProduct(Product product)
    {
        context.Product.Update(product);
        context.SaveChanges();
    }

    public void DeleteProduct(Product product)
    {
        context.Product.Remove(product);
        context.SaveChanges();
    }
}