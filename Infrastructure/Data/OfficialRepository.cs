using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class OfficialRepository(DataContext context) : IOfficialRepository
{
    public async Task<IReadOnlyList<Official>> GetAllOfficialsAsync(int businessId)
    {
        var contactInfo = await context.ContactInfo
            .Where(ci => ci.BusinessId == businessId)
            .FirstOrDefaultAsync();

        if (contactInfo == null) return [];

        var officials = await context.Official
            .Where(o => o.ContactInfoId == contactInfo.Id)
            .ToListAsync();

        return officials;
    }

    public async Task<Official?> GetOfficialByIdAsync
        (int businessId, int officialId)
    {
        var contactInfo = await context.ContactInfo
            .Where(ci => ci.BusinessId == businessId)
            .FirstOrDefaultAsync();

        if (contactInfo == null) return null;
        
        return await context.Official
            .Where(o => o.Id == officialId)
            .Where(o => o.ContactInfoId == contactInfo.Id)
            .FirstOrDefaultAsync();
    }

    public void CreateOfficial(Official official)
    {
        context.Official.Add(official);
        context.SaveChanges();
    }

    public void UpdateOfficial(Official official)
    {
        context.Official.Update(official);
        context.SaveChanges();
    }

    public void DeleteOfficial(Official official)
    {
        context.Official.Remove(official);
        context.SaveChanges();
    }
}