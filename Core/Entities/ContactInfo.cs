namespace Core.Entities;

public class ContactInfo : BaseEntity
{
    public List<string> PhoneNumbers { get; set; } = new List<string>();
    public List<string> MailAddresses { get; set; } = new List<string>();
    public List<Official> AuthorizedPersonnel { get; set; } = new List<Official>();
    
    // required foreign key property
    public int BusinessId { get; set; }
}