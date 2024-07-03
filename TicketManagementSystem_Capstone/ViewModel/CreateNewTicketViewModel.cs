using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using TicketManagementSystem_Capstone.Models;
using TicketManagementSystem_Capstone.Repository.Interfaces;

namespace TicketManagementSystem_Capstone.ViewModel;

public partial class CreateNewTicketViewModel : BaseViewModel
{
    #region Props

    // Ticket info
    [ObservableProperty]
    public string? _Title;
    [ObservableProperty]
    public string? _Description;
    [ObservableProperty]
    public string? _Status;
    [ObservableProperty]
    public string? _Priority;
    [ObservableProperty]
    public string? _AssignedTo;

    // Customer info
    [ObservableProperty]
    public string? _CustomerName;
    [ObservableProperty]
    public string? _Phone;
    [ObservableProperty]
    public string? _Email;
    [ObservableProperty]
    public string? _Address;
    [ObservableProperty]
    public string? _City;
    [ObservableProperty]
    public string? _State;
    [ObservableProperty]
    public string? _Zip;

    [ObservableProperty]
    public List<string> _Statuses = new List<string> {"", "Open", "Assigned", "In Progress",
        "Pending Customer", "On Hold", "Resolved", "Closed"};
    [ObservableProperty]
    public List<string> _Priorities = new List<string> {"", "High", "Standard"};

    [ObservableProperty]
    public List<string> _Groups = new List<string> {"","Tech Support", "Maintenance Team"};

    public ICommand ClearCommand { get; }
    public ICommand CreateTicketCommand { get; }

    private readonly IUnitOfWork UnitOfWork;

    #endregion
    public CreateNewTicketViewModel(IUnitOfWork unitOfWork)
    {
        // Init unit of work with DI 
        UnitOfWork = unitOfWork;

        // Set Commands
        ClearCommand = new RelayCommand(Clear);
        CreateTicketCommand = new RelayCommand(CreateTicket);
    }

    public void CreateTicket()
    {
        // Todo - Add check for nulls and white spaces. 

        // Create Customer
        int id = UnitOfWork.Customers.AddCustomer(new Customer
        {
            Name = CustomerName,
            Email = Email,
            Phone = Phone,
            Is_Priority = Priority == "High" ? 1 : 0,
            Address = Address,
            State = State,
            City = City,
            Zip = Zip

        });

        // Create Ticket
        UnitOfWork.Tickets.Add(new Ticket
        {
            Customer_Id = id,
            Title = Title,
            Description = Description,
            Status = Status,
            Created_Date = DateTime.Now, // Todo - Change later to get user time zone
            Updated_Date = DateTime.Now,
            Assigned_To = AssignedTo
        });

        UnitOfWork.Commit();
    }

    public void Clear()
    {
        Title = "";
        Description = "";
        Status = "";
        Priority = "";
        AssignedTo = "";
        CustomerName = "";
        Phone = "";
        Email = "";
        Address = "";
        City = "";
        State = "";
        Zip = "";
    }

}
