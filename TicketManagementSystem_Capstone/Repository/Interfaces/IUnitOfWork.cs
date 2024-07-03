namespace TicketManagementSystem_Capstone.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public ICustomerRepository Customers { get; }
        public ITicketRepository Tickets { get; }
        public IUserRepository Users { get; }
        void Commit();

    }
}
