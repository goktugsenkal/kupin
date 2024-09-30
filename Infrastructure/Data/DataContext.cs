using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseIdentityColumns();

        modelBuilder.Entity<Business>()
            .HasOne(e => e.ContactInfo)
            .WithOne()
            .HasForeignKey<ContactInfo>(e => e.BusinessId)
            .IsRequired();

        modelBuilder.Entity<Business>()
            .HasMany(e => e.Products)
            .WithOne()
            .HasForeignKey(e => e.BusinessId)
            .IsRequired();

        modelBuilder.Entity<Business>()
            .HasMany(e => e.Addresses)
            .WithOne()
            .HasForeignKey(e => e.BusinessId)
            .IsRequired();

        modelBuilder.Entity<ContactInfo>()
            .HasMany(e => e.AuthorizedPersonnel)
            .WithOne()
            .HasForeignKey(e => e.ContactInfoId)
            .IsRequired();
    }
    
    public DbSet<Business> Business { get; set; }
    public DbSet<ContactInfo> ContactInfo { get; set; }
    public DbSet<Address> Address { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Official> Official { get; set; }

}