using Core.Entities;

namespace Core.Interfaces;

public interface IContactInfoRepository
{
    // ContactInfo 
    Task<IReadOnlyList<ContactInfo>> GetAllContactInfoAsync(int businessId);
    Task<ContactInfo?> GetContactInfoByIdAsync(int businessId, int contactInfoId);
    void CreateContactInfo(ContactInfo contactInfo);
    void UpdateContactInfo(ContactInfo contactInfo);
    void DeleteContactInfo(ContactInfo contactInfo);
    
    // Official
    Task<IReadOnlyList<Official>> GetAllOfficialsAsync
        (int contactInfoId);
    Task<Official> GetOfficialByIdAsync
        (int businessId, int contactInfoId, int officialId);
    void CreateOfficial(Official official);
    void UpdateOfficial(Official official);
    void DeleteOfficial(Official official);
}