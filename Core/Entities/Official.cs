namespace Core.Entities;

public class Official : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string MailAddress { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;

    // foreign key
    public int ContactInfoId { get; set; }
}