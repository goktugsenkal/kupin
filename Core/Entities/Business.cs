namespace Core.Entities;

public class Business : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string BusinessType { get; set; } = string.Empty;
    public bool IsActive { get; set; }

    // one(business) to many
    public List<Address> Addresses { get; set; } = new List<Address>();
    public List<Product> Products { get; set; } = new List<Product>();

    // reference navigation to dependent (ContactInfo) (1 : 1)
    public ContactInfo? ContactInfo { get; set; }
}
