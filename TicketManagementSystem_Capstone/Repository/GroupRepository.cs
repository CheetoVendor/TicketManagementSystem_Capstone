using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystem_Capstone.Data;
using TicketManagementSystem_Capstone.Models;
using TicketManagementSystem_Capstone.Repository.Interfaces;

namespace TicketManagementSystem_Capstone.Repository
{
    public class GroupRepository : Repository<Group>, IRepository<Group>
    {
        public GroupRepository(DuraTechDbContext dbContext) : base(dbContext)
        {
        }

    }
}
