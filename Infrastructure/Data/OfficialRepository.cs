using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class OfficialRepository(DataContext context) : IOfficialRepository
{
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