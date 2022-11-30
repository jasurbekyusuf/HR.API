//===================================================
// Copyright (c)  coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Pease
//===================================================

using HR.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions) 
        {
             
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>()
                .Property(e => e.Email)
                .HasDefaultValueSql("'sample@gmail.com'");

            modelBuilder.Entity<Address>()
                .HasData(
                    new Address
                    {
                        Id = 9999,
                        AddressLine1 = "1, Navoiy ko'chasi",
                        AddressLine2 = "Shayxontohur tumani",
                        PostalCode = "70001",
                        City = "Toshkent",
                        Country = "O'zbekiston "
                    }
                );
        }
    }
}