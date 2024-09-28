using System.ComponentModel.DataAnnotations;

namespace Api.Dtos;

public class CreateBusinessDto
{
    [Length(2, 15)]
    public string Name { get; set; }
    public string Description { get; set; }
    public string? ImageUrl { get; set; }
}