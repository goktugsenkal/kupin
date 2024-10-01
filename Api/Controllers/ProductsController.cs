using Api.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/api/business/{businessId:int}/product")]
public class ProductsController(IProductRepository productRepository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts
        (int businessId)
    {
        var products = await productRepository
            .GetAllProductsAsync(businessId);

        return Ok(products);
    }

    [HttpGet("{productId:int}")]
    public async Task<ActionResult<Product>> GetProductById
        (int businessId, int productId)
    {
        var product = await productRepository
            .GetProductByIdAsync(businessId, productId);

        if (product == null) return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public ActionResult<Product> CreateProduct
        (int businessId, CreateProductDto productForCreate)
    {
        var product = new Product
        {
            BusinessId = businessId,
            Name = productForCreate.Name,
            Description = productForCreate.Description,
            ImageUrl = productForCreate.ImageUrl,
            QuantityInStock = productForCreate.QuantityInStock
        };
        
        productRepository.CreateProduct(product);
        return Ok(product);
    }

    [HttpPut("{productId:int}")]
    public async Task<ActionResult<Product>> UpdateProduct
        (int businessId, int productId, UpdateProductDto productForUpdate)
    {
        if(productForUpdate.Id != productId) return BadRequest();
        
        var product = await productRepository.GetProductByIdAsync(businessId, productId);
        
        if (product == null) return NotFound();
        
        product.Name = productForUpdate.Name;
        product.Description = productForUpdate.Description;
        product.ImageUrl = productForUpdate.ImageUrl;
        product.QuantityInStock = productForUpdate.QuantityInStock;
        
        productRepository.UpdateProduct(product);
        return Ok(product);
    }

    [HttpDelete("{productId:int}")]
    public async Task<ActionResult> DeleteProduct(int businessId, int productId)
    {
        var product = await productRepository.GetProductByIdAsync(businessId, productId);
        
        if(product != null) { productRepository.DeleteProduct(product); }

        return Ok();
    }
}