using Core.Entities;
using Core.Helpers;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class BusinessRepository(DataContext context) : IBusinessRepository
{
    public async Task<PagedList<Business>> GetAllBusinessesAsync
        (int pageIndex, int pageSize)
    {
        var businesses = await context.Business
            .OrderBy(b => b.Id)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var count = await context.Business.CountAsync();
        var totalPages = (int)Math.Ceiling(count / (double)pageSize);

        return new PagedList<Business>(businesses, pageIndex, totalPages);
    }

    public async Task<Business?> GetBusinessByIdAsync(int id)
    {
        return await context.Business
            .Include(b => b.Products)
            .Include(b => b.Addresses)
            .Include(b=>b.ContactInfo)
                .ThenInclude(c => c.AuthorizedPersonnel)
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