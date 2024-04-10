using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystem_Capstone.Data;
using TicketManagementSystem_Capstone.Models;

namespace TicketManagementSystem_Capstone.Repository.Interfaces
{
    public class CustomerRepository : Repository<Customer>, IRepository<Customer>
    {
        private DuraTechDbContext _dbContext;
        public CustomerRepository(DuraTechDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
