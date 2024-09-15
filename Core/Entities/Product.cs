namespace Core.Entities;

public class Product : BaseEntity
{
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
    // Stock
    public int StockQuantity { get; set; }
    // Relationship with business
    public int BusinessId { get; set; }
    public required Business Business { get; set; }
}