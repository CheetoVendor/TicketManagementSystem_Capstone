using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystem_Capstone.Models;

namespace TicketManagementSystem_Capstone.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<Customer> Customers { get; }
        public IRepository<Group> Groups { get; set; }
        public IRepository<Ticket> Tickets { get; set; }
        public IRepository<User> Users { get; set; }
        void Commit();

    }
}
