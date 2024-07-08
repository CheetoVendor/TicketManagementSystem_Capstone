using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using TicketManagementSystem_Capstone.Models;
using TicketManagementSystem_Capstone.Repository.Interfaces;

namespace TicketManagementSystem_Capstone.ViewModel;

public partial class CreateNewTicketViewModel : BaseViewModel
{
    #region Props

    // Ticket info
    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "Title is required.")]
    public string? _Title;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "Description is required.")]
    public string? _Description;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "Status is required.")]
    public string? _Status;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "Priority is required.")]
    public string? _Priority;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "Assigned team is required.")]
    public string? _AssignedTo;

    // Customer info
    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "Customer name is required.")]
    public string? _CustomerName;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "Phone number is required.")]
    [RegularExpression(@"^\(\d{3}\)-\d{3}-\d{4}$", ErrorMessage = "Phone number must be in the format (###)-###-####.")]
    public string? _Phone;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "Email is required.")]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Email must be in a correct format.")]
    public string? _Email;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "Address is required.")]
    public string? _Address;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "City is required.")]
    public string? _City;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "State is required.")]
    public string? _State;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "Zip code is required.")]
    [MinLength(5, ErrorMessage = "Zip code must be valid.")]
    [MaxLength(5, ErrorMessage = "Zip code must be valid.")]
    public string? _Zip;

    [ObservableProperty]
    public List<string> _Statuses = ["", "Open", "Assigned", "In Progress",
        "Pending Customer", "On Hold", "Resolved", "Closed"];
    [ObservableProperty]
    public List<string> _Priorities = ["", "High", "Standard"];

    [ObservableProperty]
    public List<string> _Groups = ["", "Tech Support", "Maintenance Team"];

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
        ValidateAllProperties();
        if (HasErrors)
        {
            return;
        }

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
