using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using TicketManagementSystem_Capstone.Models;
using TicketManagementSystem_Capstone.Repository.Interfaces;

namespace TicketManagementSystem_Capstone.ViewModel;

public partial class CreateNewCustomerViewModel : BaseViewModel, IBaseTabViewModel
{
    public string TabName { get; set; } = "Add Customer";

    [ObservableProperty]
    public List<string> _Priorities = new List<string> { "", "High", "Standard" };

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "Customer name is required.")]
    [MinLength(1, ErrorMessage = "")]
    [NotifyPropertyChangedFor(nameof(HasErrors))]
    public string? _CustomerName;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "Phone number is required.")]
    [RegularExpression(@"^\(\d{3}\)-\d{3}-\d{4}$", ErrorMessage = "Phone number must be in the format (###)-###-####.")]
    [NotifyPropertyChangedFor(nameof(HasErrors))]
    public string? _Phone;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "Email is required.")]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Email must be valid.")]
    [NotifyPropertyChangedFor(nameof(HasErrors))]
    public string? _Email;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "Priority is required.")]
    [NotifyPropertyChangedFor(nameof(HasErrors))]
    public string? _Priority;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "Address is required.")]
    [NotifyPropertyChangedFor(nameof(HasErrors))]
    public string? _Address;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "City is required.")]
    [NotifyPropertyChangedFor(nameof(HasErrors))]
    public string? _City;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "State is required.")]
    [NotifyPropertyChangedFor(nameof(HasErrors))]
    public string? _State;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "Zip code is required.")]
    [MinLength(5, ErrorMessage = "Zip code must be 5 numbers.")]
    [MaxLength(5, ErrorMessage = "Zip code must be 5 numbers.")]
    [NotifyPropertyChangedFor(nameof(HasErrors))]
    public string? _Zip;
    
    public ICommand CreateCustomerCommand { get; }
    public ICommand ClearCommand { get; }
    public IUnitOfWork UnitOfWork { get; }

    public CreateNewCustomerViewModel(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
        CreateCustomerCommand = new RelayCommand(AddCustomer, CanAddCustomer);
        ClearCommand = new RelayCommand(Clear);
    }

    private void Clear()
    {
        CustomerName = "";
        Phone = "";
        Email = "";
        Priority = "";
        Address = "";
        City = "";
        State = "";
        Zip = "";
        ClearErrors();
    }

    private void AddCustomer()
    {
        ValidateAllProperties();
        if (HasErrors)
        {
            return;
        }

        UnitOfWork.Customers.Add(new Customer
        {
            Name = CustomerName,
            Phone = Phone,
            Email = Email,
            Is_Priority = Priority == "High" ? 1 : 0,
            Address = Address,
            City = City,
            State = State,
            Zip = Zip
        });

        UnitOfWork.Commit();
    }

    private bool CanAddCustomer() => !HasErrors;

}
