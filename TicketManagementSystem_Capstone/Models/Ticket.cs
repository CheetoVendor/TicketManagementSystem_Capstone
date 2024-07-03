namespace TicketManagementSystem_Capstone.Models;

public class Ticket
{
    public int Id { get; set; }
    public int Customer_Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public DateTime Created_Date { get; set; }
    public DateTime Updated_Date { get; set; }
    public string Assigned_To { get; set; }
}
