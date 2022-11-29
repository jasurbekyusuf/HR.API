//===================================================
// Copyright (c)  coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Pease
//===================================================

using Microsoft.EntityFrameworkCore;

namespace HR.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) 
            : base(dbContextOptions) 
        { 
        
        }
        public DbSet<Employee> Employees { get; set; }
    }
}