using TicketManagementSystem_Capstone.Data;
using TicketManagementSystem_Capstone.Repository.Interfaces;

namespace TicketManagementSystem_Capstone.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable, IAsyncDisposable
    {
        public ICustomerRepository Customers { get; }
        public IGroupRepository Groups { get; set; }
        public ITicketRepository Tickets { get; set; }
        public IUserRepository Users { get; set; }

        public DuraTechDbContext DbContext { get; set; }

        public UnitOfWork(DuraTechDbContext dbContext)
        {
            DbContext = dbContext;
            Customers = new CustomerRepository(dbContext);
            Groups = new GroupRepository(dbContext);
            Tickets = new TicketRepository(dbContext);
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
