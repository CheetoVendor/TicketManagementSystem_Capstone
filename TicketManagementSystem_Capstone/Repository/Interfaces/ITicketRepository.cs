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
        public List<Ticket> GetAll();

        public List<Ticket> GetActive();
    }
}
