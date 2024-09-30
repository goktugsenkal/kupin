using System.ComponentModel.DataAnnotations;

namespace Api.Dtos;

public class CreateBusinessDto
{
    [Length(2, 15)]
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    [AllowedValues("Restaurant", "Cafe", "Gym", ErrorMessage = "Business Type can be one of the following values: Restaurant, Cafe, Gym")]
    public required string BusinessType { get; set; }
}