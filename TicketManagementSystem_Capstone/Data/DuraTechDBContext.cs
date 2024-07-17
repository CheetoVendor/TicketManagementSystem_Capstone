using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TicketManagementSystem_Capstone.Models;

namespace TicketManagementSystem_Capstone.Data;

public class DuraTechDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Customer> Customer { get; set; }

    public DbSet<Ticket> Ticket { get; set; }

    private readonly string _connectionString;

    public DuraTechDbContext(DbContextOptions<DuraTechDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _connectionString = configuration.GetConnectionString("default");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_connectionString);
        base.OnConfiguring(optionsBuilder);
    }
}
