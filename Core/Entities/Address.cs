namespace Core.Entities;

public class Address : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string County { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string AddressDescription { get; set; } = string.Empty;
    
    // required foreign key
    public int BusinessId { get; set; }
}