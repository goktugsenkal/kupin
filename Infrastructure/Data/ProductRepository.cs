using Core.Entities;
using Core.Helpers;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ProductRepository(DataContext context) : IProductRepository
{
    public async Task<PagedList<Product>> GetAllProductsAsync
        (int businessId, int pageIndex, int pageSize)
    {
        var products = await context.Product
            .Where(p => p.BusinessId == businessId)
            .OrderBy(p => p.Id)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var count = await context.Product.CountAsync();
        var totalPages = (int)Math.Ceiling(count / (double)pageSize);

        return new PagedList<Product>(products, pageIndex, pageSize);
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