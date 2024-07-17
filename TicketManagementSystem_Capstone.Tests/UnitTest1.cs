using Moq;
using TicketManagementSystem_Capstone.Models;
using TicketManagementSystem_Capstone.Repository.Interfaces;

namespace TicketManagementSystem_Capstone.Tests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestGetTechUsersCorrect()
    {
        var mock = new Mock<IUserRepository>();
        mock.Setup(x => x.GetTechnicalSupportUsers()).Returns( new List<User>
        { 
            new User { Id = 1, Team = "Tech Support" },
            new User { Id = 2, Team = "Tech Support" },
            new User { Id = 3, Team = "Tech Support" },
        });

       var techUsers = mock.Object.GetTechnicalSupportUsers();

        Assert.IsTrue(techUsers.All(x => x.Team == "Tech Support"));
        Assert.AreEqual(3, techUsers.Count());
    }


}