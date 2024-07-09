using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using TicketManagementSystem_Capstone.Models;
using TicketManagementSystem_Capstone.Repository.Interfaces;

namespace TicketManagementSystem_Capstone.ViewModel.Administration;

public partial class CreateEmployeeViewModel : BaseViewModel, IBaseTabViewModel
{
    public string TabName { get; set; } = "Add Employee";

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "Email is required.")]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Email must be valid.")]
    public string? _Email;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "First name is required.")]
    public string? _FirstName;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "Last name is required.")]
    public string? _LastName;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "Team assignment is required.")]
    public string? _Team;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "User password is required.")]
    public string? _Password;

    [ObservableProperty]
    public List<string> _Teams = new List<string> { "", "Tech Support", "Maintenance" };

    private IUnitOfWork _unitOfWork;

    public ICommand CreateUserCommand { get; }

    public ICommand ClearCommand { get; }

    public bool CanCreateUser() => !HasErrors;

    public CreateEmployeeViewModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        CreateUserCommand = new RelayCommand(CreateUser, CanCreateUser);
        ClearCommand = new RelayCommand(Clear);

    }

    private void Clear()
    {
        Email = "";
        FirstName = "";
        LastName = "";
        Team = "";
        Password = "";
        ClearErrors();
    }

    private void CreateUser()
    {
        ValidateAllProperties();
        if (!HasErrors)
        {
            _unitOfWork.Users.Add(new User
            {
                First_Name = FirstName,
                Last_Name = LastName,
                Email = Email,
                Team = Team,
                Password = Password,
            });

            _unitOfWork.Commit();

            Clear();
        }
    }
}
