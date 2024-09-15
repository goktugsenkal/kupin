namespace Core.Entities;

public class Address : BaseEntity
{
    public required string Street { get; set; }
    public required string County { get; set; }
    public required string City { get; set; }
    public string? Description { get; set; }
}