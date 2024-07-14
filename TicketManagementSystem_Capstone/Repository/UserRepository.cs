using TicketManagementSystem_Capstone.Data;
using TicketManagementSystem_Capstone.Models;
using TicketManagementSystem_Capstone.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TicketManagementSystem_Capstone.Repository;

public class UserRepository : Repository<User>, IUserRepository
{
    public DuraTechDbContext _dbContext;

    public UserRepository(DuraTechDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Used to verify an email is in the database.
    /// </summary>
    /// <param name="email">Email provided during login.</param>
    /// <returns></returns>
    public bool EmailExists(string email) =>
        _dbContext.Set<User>().Any(user => user.Email == email);

    /// <summary>
    /// Used to determine whether a login is correct or not.
    /// </summary>
    /// <param name="email">Email provided at login attempt.</param>
    /// <param name="password">Password provided at login attempt.</param>
    /// <returns></returns>
    public bool IsLoginCorrect(string email, string password)
    {
        var user = _dbContext.Users.FirstOrDefault(user => user.Email == email && user.Password == password);

        return user != null;
    }


    public bool IsEmailUnique(string email) => !EmailExists(email);

    public IEnumerable<User> GetTechnicalSupportUsers()
    {
        return _dbContext.Set<User>().Where(user => user.Team == "Tech Support");
    }

    public IEnumerable<User> GetMaintenanceUsers()
    {
        return _dbContext.Set<User>().Where(user => user.Team == "Maintenance Team");
    }

    public User LoginUser(string email, string password)
    {
        return _dbContext.Set<User>().SingleOrDefault(user => user.Email.ToLower() == email.ToLower() && user.Password == password);
    }
}
