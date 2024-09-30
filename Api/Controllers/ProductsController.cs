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
            .GetAllProducts(businessId);

        return Ok(products);
    }

    [HttpGet("{productId:int}")]
    public async Task<ActionResult<Product>> GetProductById
        (int businessId, int productId)
    {
        var product = await productRepository
            .GetProductById(businessId, productId);

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
        
        productRepository.CreateProduct(businessId, product);
        return Ok(product);
    }
}