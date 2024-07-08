using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Globalization;
using System.Windows;
using System.Windows.Input;
using TicketManagementSystem_Capstone.Repository.Interfaces;

namespace TicketManagementSystem_Capstone.ViewModel;

// https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/observablerecipient
// Use to handle login ^
public partial class LoginViewModel : BaseViewModel
{
    [ObservableProperty]
    public string? _email;

    [ObservableProperty]
    public string? _password;

    [ObservableProperty]
    public string? _errorMessage;

    public ICommand LoginCommand { get; }

    private readonly IUnitOfWork _unitOfWork;

    public LoginViewModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        LoginCommand = new RelayCommand(Login);

        // Detect Culture info
        CultureInfo info = CultureInfo.CurrentCulture;
        MessageBox.Show("asd");
    }

    private void Login()
    {

        if (_unitOfWork.Users.IsLoginCorrect(Email, Password))
        {

        }
        else
        {
            ErrorMessage = "Email address or password is incorrect.";
        }

    }
}
