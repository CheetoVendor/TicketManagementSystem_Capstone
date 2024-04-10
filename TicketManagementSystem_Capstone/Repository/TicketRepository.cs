using TicketManagementSystem_Capstone.Data;
using TicketManagementSystem_Capstone.Models;
using TicketManagementSystem_Capstone.Repository.Interfaces;

namespace TicketManagementSystem_Capstone.Repository;

public class TicketRepository : Repository<Ticket>, IRepository<Ticket>
{
    public TicketRepository(DuraTechDbContext dbContext) : base(dbContext)
    {
    }
}
