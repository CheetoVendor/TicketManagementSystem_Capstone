using TicketManagementSystem_Capstone.Data;
using TicketManagementSystem_Capstone.Models;

namespace TicketManagementSystem_Capstone.Repository.Interfaces;

public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    DuraTechDbContext dbContext;

    public CustomerRepository(DuraTechDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }

    public Customer GetCustomerById(int id)
    {
        return dbContext.Customer.FirstOrDefault(x => x.Id == id);
    }

    public int AddCustomer(Customer customer)
    {
        var entity = dbContext.Customer.Add(customer).Entity;
        dbContext.SaveChanges();
        return entity.Id;
    }


}
