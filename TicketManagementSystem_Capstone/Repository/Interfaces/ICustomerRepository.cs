using TicketManagementSystem_Capstone.Models;

namespace TicketManagementSystem_Capstone.Repository.Interfaces;

public interface ICustomerRepository : IRepository<Customer>
{
    public Customer GetCustomerById(int id);

    public int AddCustomer(Customer customer);
}