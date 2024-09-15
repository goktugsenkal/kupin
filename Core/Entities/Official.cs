namespace Core.Entities;

public class Official : BaseEntity
{
    public required string Name { get; set; }
    public required string MailAddress { get; set; }
    public required string PhoneNumber { get; set; }
}