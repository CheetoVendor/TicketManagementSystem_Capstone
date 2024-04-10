using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketManagementSystem_Capstone.Data;
using TicketManagementSystem_Capstone.Models;
using TicketManagementSystem_Capstone.Repository.Interfaces;

namespace TicketManagementSystem_Capstone.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable, IAsyncDisposable
    {
        public IRepository<Customer> Customers { get; } 
        public IRepository<Group> Groups { get; set; }
        public IRepository<Ticket> Tickets { get; set; }
        public IRepository<User> Users { get; set; }
        public DuraTechDbContext DbContext { get; set; }

        public UnitOfWork(DuraTechDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }

        public async ValueTask DisposeAsync()
        {
            await DbContext.DisposeAsync();
        }
    }
}
