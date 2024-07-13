using Microsoft.EntityFrameworkCore;
using TicketManagementSystem_Capstone.Models;

namespace TicketManagementSystem_Capstone.Data;

public class DuraTechDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();

    public DbSet<Customer> Customer => Set<Customer>();

    public DbSet<Ticket> Ticket => Set<Ticket>();

    public DuraTechDbContext(DbContextOptions<DuraTechDbContext> options)
        : base(options)
    { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite("Data Source=duretech.db");
    }
}
