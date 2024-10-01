using Core.Entities;

namespace Core.Interfaces;

public interface IAddressRepository
{
    Task<IReadOnlyList<Address>> GetAllAddressesAsync(int businessId);
    Task<Address?> GetAddressByIdAsync(int businessId, int productId);
    void CreateAddress(Address address);
    void UpdateAddress(Address address);
    void DeleteAddress(Address address);
}