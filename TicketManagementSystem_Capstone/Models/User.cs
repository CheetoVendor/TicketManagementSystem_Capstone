﻿namespace TicketManagementSystem_Capstone.Models;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string First_Name { get; set; }
    public string Last_Name { get; set; }
    public string Team { get; set; }

    public int Admin { get; set; }

}
