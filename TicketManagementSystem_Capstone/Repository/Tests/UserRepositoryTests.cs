using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicketManagementSystem_Capstone.Data;
using TicketManagementSystem_Capstone.Models;

namespace TicketManagementSystem_Capstone.Repository.Tests;

[TestClass]
public class UserRepositoryTests
{
    
    private DuraTechDbContext _dbContext;

    [TestMethod]
    public void TestGetTechUsersCorrect()
    {
        List<User> users = new List<User>
        {
            new User { Id = 1, Team = "Tech Support"},
            new User { Id = 1, Team = "Tech Support"},
            new User { Id = 1, Team = "Tech Support"},
            new User { Id = 1, Team = "Maintenance Team"},
        };


    }
}
