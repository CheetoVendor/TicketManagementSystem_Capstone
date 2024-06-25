using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystem_Capstone.Models;

namespace TicketManagementSystem_Capstone.Repository.Interfaces
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        // Gets All tickets
        public List<Ticket> GetAll();

        // Gets open tickets
        public List<Ticket> GetOpen();

        // Gets assigned tickets
        public List<Ticket> GetAssigned();

        // Gets in progress tickets
        public List<Ticket> GetInProgress();

        // Gets tickets pending customer action
        public List<Ticket> GetPendingCustomer();

        // Gets tickets on hold
        public List<Ticket> GetOnHold();

        // Gets resolved tickets
        public List<Ticket> GetResolved();

        // Gets closed tickets
        public List<Ticket> GetClosed();

        

        
    }
}
