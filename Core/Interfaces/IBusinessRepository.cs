using Core.Entities;
using Core.Helpers;

namespace Core.Interfaces;

public interface IBusinessRepository
{
    Task<PagedList<Business>> GetAllBusinessesAsync(int pageIndex, int pageSize);
    Task<Business?> GetBusinessByIdAsync(int id);
    void CreateBusiness(Business business);
    void UpdateBusiness(Business business);
    void DeleteBusiness(Business business);
}