using TicketManagementSystem_Capstone.Models;

namespace TicketManagementSystem_Capstone.Repository.Interfaces;

public interface IUserRepository : IRepository<User>
{
    public bool EmailExists(string email);
    public bool IsLoginCorrect(string email, string password);

    public bool IsEmailUnique(string email);

    public IEnumerable<User> GetTechnicalSupportUsers();

    public IEnumerable<User> GetMaintenanceUsers();
    public User LoginUser(string email, string password);
}
