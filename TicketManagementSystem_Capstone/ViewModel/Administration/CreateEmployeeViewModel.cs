using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using TicketManagementSystem_Capstone.Models;
using TicketManagementSystem_Capstone.Repository.Interfaces;

namespace TicketManagementSystem_Capstone.ViewModel.Administration;

public partial class CreateEmployeeViewModel : BaseViewModel, IBaseTabViewModel
{
    public string TabName { get; set; } = "Add Employee";

    [ObservableProperty]
    public string? _Email;

    [ObservableProperty]
    public string? _FirstName;

    [ObservableProperty]
    public string? _LastName;

    [ObservableProperty]
    public string? _Team;

    [ObservableProperty]
    public string? _Password;

    [ObservableProperty]
    public List<string> _Teams = new List<string> { "", "Tech Support", "Maintenance" };

    [ObservableProperty]
    public List<string> _PasswordOptions = new List<string> { "", "Temporary Password", "Set Password" };

    [ObservableProperty]
    public string? _PasswordOptionSelection;

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
        PasswordOptionSelection = "";
    }

    private void CreateUser()
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
