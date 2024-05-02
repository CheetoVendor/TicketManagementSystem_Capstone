using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketManagementSystem_Capstone.Data;
using TicketManagementSystem_Capstone.Models;
using TicketManagementSystem_Capstone.Repository.Interfaces;

namespace TicketManagementSystem_Capstone.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        public UserRepository(DuraTechDbContext dbContext) : base(dbContext)
        {
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
            return _dbContext.Set<User>().Any(user => user.Email.ToLower().Equals(email.ToLower()) && user.Password == password);
        }
            

        public bool IsEmailUnique(string email) => !EmailExists(email);

    }
}
