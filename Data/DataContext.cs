using MediatRSample.Domain.Customer.Entity;
using Microsoft.EntityFrameworkCore;

namespace MediatRSample.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {            
        }

        public DbSet<CustomerEntity> Customers { get; set; }        
    }
}