using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class BusinessRepository(DataContext context) : IBusinessRepository
{
    public async Task<IReadOnlyList<Business>> GetAllBusinessesAsync()
    {
        return await context.Business
                // .Include(b => b.Products) <-- INCLUDE STATEMENTS HERE <--
            .ToListAsync();
    }

    public async Task<Business?> GetBusinessByIdAsync(int id)
    {
        return await context.Business
            .Include(b => b.Products)
            .Include(b => b.Addresses)
            .Include(b=>b.ContactInfo).ThenInclude(c => c.AuthorizedPersonnel)
            .SingleOrDefaultAsync(b => b.Id == id);
    }

    public void CreateBusiness(Business business)
    {
        context.Business.Add(business);
        context.SaveChanges();
    }

    public void UpdateBusiness(Business business)
    {
        context.Business.Update(business);
        context.SaveChanges();
    }

    public void DeleteBusiness(Business business)
    {
        context.Business.Remove(business);
        context.SaveChanges();
    }
}