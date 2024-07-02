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
        using(dbContext)
        {
            int i = dbContext.Customer.Add(customer).Entity.Id;
            dbContext.SaveChanges();
            return i;
        }
        
    }


}
