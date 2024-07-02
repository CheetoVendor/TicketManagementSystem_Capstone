using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystem_Capstone.Models;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    
    public string Phone { get; set; }
    public int Is_Priority { get; set; }
    public string State { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Zip { get; set; }
}
