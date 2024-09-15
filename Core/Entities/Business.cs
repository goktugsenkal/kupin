namespace Core.Entities;

public class Business : BaseEntity
{
    public required string Name { get; set; }
    public string? ImageUrl { get; set; }
    public required string BusinessType { get; set; }
    public Address? Address { get; set; }
    public ContactInfo? ContactInfo { get; set; }
    public List<Product> Products { get; set; } = [];
    public bool ActiveStatus { get; set; }

    public void ActivateBusiness()
    {
        ActiveStatus = true;
    }

    public void DeactivateBusiness()
    {
        ActiveStatus = false;
    }
}
