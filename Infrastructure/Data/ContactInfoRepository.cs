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
        throw new NotImplementedException();
    }

    public void UpdateContactInfo(ContactInfo contactInfo)
    {
        throw new NotImplementedException();
    }

    public void DeleteContactInfo(ContactInfo contactInfo)
    {
        throw new NotImplementedException();
    }
    
    //
    // Official Table Queries
    //
    
    public async Task<IReadOnlyList<Official>> GetAllOfficialsAsync(int contactInfoId)
    {
        return await context.Official
            .Where(o => o.Id == contactInfoId)
            .ToListAsync();
    }

    public Task<Official> GetOfficialByIdAsync
        (int businessId, int contactInfoId, int officialId)
    {
        throw new NotImplementedException();
    }

    public void CreateOfficial(Official official)
    {
        throw new NotImplementedException();
    }

    public void UpdateOfficial(Official official)
    {
        throw new NotImplementedException();
    }

    public void DeleteOfficial(Official official)
    {
        throw new NotImplementedException();
    }
}