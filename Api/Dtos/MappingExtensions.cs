using Core.Entities;

namespace Api.Dtos;

public static class MappingExtensions
{
    public static List<Official> ToListOfOfficials(this List<CreateOfficialDto> dtos)
    {
        var officials = new List<Official>();
        
        foreach (var dto in dtos)
        {
            var official = new Official
            {
                Name = dto.Name,
                MailAddress = dto.MailAddress,
                PhoneNumber = dto.PhoneNumber
            };
            officials.Add(official);
        }

        return officials;
    }
}