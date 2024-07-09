using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Globalization;
using System.Windows;
using System.Windows.Input;
using TicketManagementSystem_Capstone.Repository.Interfaces;
using TicketManagementSystem_Capstone.Services;

namespace TicketManagementSystem_Capstone.ViewModel;

public partial class LoginViewModel : BaseViewModel
{
    [ObservableProperty]
    public string? _email;

    [ObservableProperty]
    public string? _password;

    [ObservableProperty]
    public string? _errorMessage;

    public ICommand LoginCommand { get; }
    public ICommand ExitCommand { get; }
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserService _userService;

    public IVVMS _viewViewModelService;

    public LoginViewModel(VVMService viewViewModelService, IUnitOfWork unitOfWork, UserService userService)
    {
        _unitOfWork = unitOfWork;
        _viewViewModelService = viewViewModelService;
        _userService = userService;

        LoginCommand = new RelayCommand(Login);
        ExitCommand = new RelayCommand(Exit);

        // Culture info
        CultureInfo info = CultureInfo.CurrentCulture;
        _userService.CultureInfo = info;
    }

    private void Exit()
    {
        Application.Current.Shutdown();
    }

    private void Login()
    {

        if (_unitOfWork.Users.IsLoginCorrect(Email, Password))
        {
            _userService.User = _unitOfWork.Users.LoginUser(Email, Password);


            Application.Current.MainWindow.Hide();

            Application.Current.MainWindow = _viewViewModelService.GetMainView();
            Application.Current.MainWindow.Show();
        }
        else
        {
            ErrorMessage = "Email address or password is incorrect.";
        }

    }
}
