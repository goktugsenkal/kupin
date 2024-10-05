using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ContactInfoRepository(DataContext context) : IContactInfoRepository
{
    public async Task<IReadOnlyList<ContactInfo>> GetAllContactInfoAsync(int businessId)
    {
        return await context.ContactInfo
            .Where(ci => ci.BusinessId == businessId)
            .Include(ci => ci.AuthorizedPersonnel)
            .ToListAsync();
    }   

    public async Task<ContactInfo?> GetContactInfoByIdAsync(int businessId, int contactInfoId)
    {
        return await context.ContactInfo
            .Where(ci => ci.BusinessId == businessId)
            .Where(ci => ci.Id == contactInfoId)
            .Include(ci => ci.AuthorizedPersonnel)
            .FirstOrDefaultAsync();
    }

    public void CreateContactInfo(ContactInfo contactInfo)
    {
        context.ContactInfo.Add(contactInfo);
        context.SaveChanges();
    }

    public void UpdateContactInfo(ContactInfo contactInfo)
    {
        context.ContactInfo.Update(contactInfo);
        context.SaveChanges();
    }

    public void DeleteContactInfo(ContactInfo contactInfo)
    {
        context.ContactInfo.Remove(contactInfo);
        context.SaveChanges();
    }
}