namespace Core.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public int QuantityInStock { get; set; }
    
    // foreign key
    public int BusinessId { get; set; }
}