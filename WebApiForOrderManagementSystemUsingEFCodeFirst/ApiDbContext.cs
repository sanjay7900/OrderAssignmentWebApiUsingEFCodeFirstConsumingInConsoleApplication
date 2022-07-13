using Microsoft.EntityFrameworkCore;
using WebApiForOrderManagementSystemUsingEFCodeFirst.Models;

namespace WebApiForOrderManagementSystemUsingEFCodeFirst
{
    public class ApiDbContext:DbContext
    {
        public ApiDbContext() { }
        public ApiDbContext(DbContextOptions options) : base(options) { }
        public DbSet<CustomerMaster> CustomerMaster { set; get; }
        public DbSet<ItemMaster> ItemMaster { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseSqlServer(@"Data Source=DESKTOP-AMR2CQS\MSSQLSERVER01;Initial Catalog=WebApiForOrderAssignment;Integrated Security=True");
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CustomerMaster>().HasIndex(u => u.EmailAddress).IsUnique();
            builder.Entity<ItemMaster>().HasIndex(u => u.Name).IsUnique();

        }

    }
}
