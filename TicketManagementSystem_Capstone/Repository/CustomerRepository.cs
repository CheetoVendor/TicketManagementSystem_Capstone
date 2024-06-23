using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystem_Capstone.Data;
using TicketManagementSystem_Capstone.Models;

namespace TicketManagementSystem_Capstone.Repository.Interfaces
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        DuraTechDbContext dbContext;
        public CustomerRepository(DuraTechDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public Customer GetCustomerById(int id)
        {
            return (Customer)dbContext.Customers.Where(x => x.Id == id);
        }
    }
}
