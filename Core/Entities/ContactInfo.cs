namespace Core.Entities;

public class ContactInfo : BaseEntity
{
    public required List<string> PhoneNumbers { get; set; }
    public required List<string> MailAddresses { get; set; }
    public required List<Official> AuthorizedPersonnel { get; set; }
}