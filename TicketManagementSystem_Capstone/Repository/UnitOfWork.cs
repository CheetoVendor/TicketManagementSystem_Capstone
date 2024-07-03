using TicketManagementSystem_Capstone.Data;
using TicketManagementSystem_Capstone.Repository.Interfaces;

namespace TicketManagementSystem_Capstone.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICustomerRepository Customers { get; private set; }
        public ITicketRepository Tickets { get; private set; }
        public IUserRepository Users { get; private set; }

        private DuraTechDbContext _dbContext;

        public UnitOfWork(DuraTechDbContext dbContext)
        {
            _dbContext = dbContext;
            Customers = new CustomerRepository(_dbContext);
            Tickets = new TicketRepository(_dbContext);
            Users = new UserRepository(_dbContext);
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
