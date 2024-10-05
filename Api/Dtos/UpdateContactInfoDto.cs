namespace Api.Dtos;

public class UpdateContactInfoDto
{
    public List<string> PhoneNumbers { get; set; } = new List<string>();
    public List<string> MailAddresses { get; set; } = new List<string>();
    public List<CreateOfficialDto> AuthorizedPersonnel { get; set; } = new List<CreateOfficialDto>();
}