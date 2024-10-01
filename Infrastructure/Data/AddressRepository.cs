using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AddressRepository(DataContext context) : IAddressRepository
{
    public async Task<IReadOnlyList<Address>> GetAllAddressesAsync(int businessId)
    {
        return await context.Address.Where(a => a.BusinessId == businessId).ToListAsync();
    }

    public async Task<Address?> GetAddressByIdAsync(int businessId, int addressId)
    {
        return await context.Address
            .Where(a=>a.BusinessId == businessId)
            .Where(a=>a.Id == addressId)
            .FirstOrDefaultAsync();
    }

    public void CreateAddress(Address address)
    {
        context.Address.Add(address);
        context.SaveChanges();
    }

    public void UpdateAddress(Address address)
    {
        context.Address.Update(address);
        context.SaveChanges();
    }

    public void DeleteAddress(Address address)
    {
        context.Address.Remove(address);
        context.SaveChanges();
    }
}