using Core.Entities;

namespace Core.Interfaces;

public interface IOfficialRepository
{
    Task<IReadOnlyList<Official>> GetAllOfficialsAsync
        (int contactInfoId);
    Task<Official> GetOfficialByIdAsync
        (int businessId, int contactInfoId, int officialId);
    void CreateOfficial(Official official);
    void UpdateOfficial(Official official);
    void DeleteOfficial(Official official);
}