namespace TicketManagementSystem_Capstone.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        public ICustomerRepository Customers { get; }
        public IGroupRepository Groups { get; set; }
        public ITicketRepository Tickets { get; set; }
        public IUserRepository Users { get; set; }
        void Commit();

    }
}
