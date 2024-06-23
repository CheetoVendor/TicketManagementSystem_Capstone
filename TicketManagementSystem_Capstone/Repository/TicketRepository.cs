using TicketManagementSystem_Capstone.Data;
using TicketManagementSystem_Capstone.Models;
using TicketManagementSystem_Capstone.Repository.Interfaces;

namespace TicketManagementSystem_Capstone.Repository;

public class TicketRepository : Repository<Ticket>, ITicketRepository
{
    DuraTechDbContext dbContext;
    public TicketRepository(DuraTechDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }

    // TEST 
    public List<Ticket> GetActive()
    {
        return dbContext.Ticket.Where(ticket => ticket.Status == "Active").ToList();
    }

    public List<Ticket> GetAll()
    {
        return dbContext.Ticket.ToList();
    }
}
