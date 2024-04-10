using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using TicketManagementSystem_Capstone.Models;

namespace TicketManagementSystem_Capstone.Data
{
    public class DuraTechDbContext : DbContext
    {
        public DuraTechDbContext(DbContextOptions<DuraTechDbContext> options) 
            : base(options)
        {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
