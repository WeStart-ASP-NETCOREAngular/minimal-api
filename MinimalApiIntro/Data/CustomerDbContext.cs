using Microsoft.EntityFrameworkCore;
using MinimalApiIntro.Models;

namespace MinimalApiIntro.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
    }
}
