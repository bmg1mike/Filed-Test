using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentState> PaymentState { get; set; }
       public DataContext(DbContextOptions options):base(options)
       {
           
       } 
    }
}