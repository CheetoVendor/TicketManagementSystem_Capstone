using TicketManagementSystem_Capstone.Data;
using TicketManagementSystem_Capstone.Models;
using TicketManagementSystem_Capstone.Repository.Interfaces;

namespace TicketManagementSystem_Capstone.Repository;

public class TicketRepository : Repository<Ticket>, ITicketRepository
{
    public DuraTechDbContext dbContext;
    public TicketRepository(DuraTechDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }
    
    // Gets all tickets 
    public List<Ticket> GetAll()
    {
        return dbContext.Ticket.ToList();
    }

    // Get ticket assigned to group
    public List<Ticket> GetAssigned(string team)
    {
        return dbContext.Ticket.Where(ticket => ticket.Assigned_To == team).ToList();
    }

    // Gets Tickets that are Open
    public List<Ticket> GetOpen()
    {
        return dbContext.Ticket.Where(ticket => ticket.Status == "Open").ToList();
    }

    public List<Ticket> GetInProgress()
    {
        return dbContext.Ticket.Where(ticket => ticket.Status == "In Progress").ToList();
    }

    public List<Ticket> GetPendingCustomer()
    {
        return dbContext.Ticket.Where(ticket => ticket.Status == "Pending Customer").ToList();
    }

    public List<Ticket> GetOnHold()
    {
        return dbContext.Ticket.Where(ticket => ticket.Status == "On Hold").ToList();
    }

    public List<Ticket> GetResolved()
    {
        return dbContext.Ticket.Where(ticket => ticket.Status == "Resolved").ToList();
    }

    public List<Ticket> GetClosed()
    {
        return dbContext.Ticket.Where(ticket => ticket.Status == "Closed").ToList();
    }
}
