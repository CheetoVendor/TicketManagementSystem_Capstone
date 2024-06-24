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
    
    // Gets Tickets that are active/in progress
    public List<Ticket> GetActive()
    {
        return dbContext.Ticket.Where(ticket => ticket.Status == "Active").ToList();
    }

    // Gets all tickets 
    public List<Ticket> GetAll()
    {
        return dbContext.Ticket.ToList();
    }
}
