using Core.Entities;

namespace Core.Interfaces;

public interface IBusinessRepository
{
    Task<IReadOnlyList<Business>> GetAllBusinessesAsync();
    Task<Business?> GetBusinessByIdAsync(int id);
    void CreateBusiness(Business business);
    void UpdateBusiness(Business business);
    void DeleteBusiness(Business business);
}