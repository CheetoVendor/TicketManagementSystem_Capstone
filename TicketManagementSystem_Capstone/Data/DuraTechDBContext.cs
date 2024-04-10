using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using TicketManagementSystem_Capstone.Models;

namespace TicketManagementSystem_Capstone.Data
{
    public class DuraTechDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();

        public DbSet<Group> Groups => Set<Group>();
        public DbSet<Customer> Customers => Set<Customer>();

        public DbSet<Ticket> Tickets  => Set<Ticket>();

        public DuraTechDbContext(DbContextOptions<DuraTechDbContext> options) 
            : base(options)
        {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
