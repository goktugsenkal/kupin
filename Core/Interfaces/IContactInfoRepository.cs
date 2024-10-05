using Core.Entities;

namespace Core.Interfaces;

public interface IContactInfoRepository
{
    Task<IReadOnlyList<ContactInfo>> GetAllContactInfoAsync(int businessId);
    Task<ContactInfo?> GetContactInfoByIdAsync(int businessId, int contactInfoId);
    void CreateContactInfo(ContactInfo contactInfo);
    void UpdateContactInfo(ContactInfo contactInfo);
    void DeleteContactInfo(ContactInfo contactInfo);
}