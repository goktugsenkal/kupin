namespace Api.Dtos;

public class UpdateAddressDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string County { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string AddressDescription { get; set; } = string.Empty;
}