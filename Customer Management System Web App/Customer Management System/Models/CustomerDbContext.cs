using Microsoft.EntityFrameworkCore;

namespace Customer_Management_System.Models
{
    public class CustomerDbContext:DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options):base(options)
        { }
        public DbSet<Customer> Customers { get; set; }
    }
}
