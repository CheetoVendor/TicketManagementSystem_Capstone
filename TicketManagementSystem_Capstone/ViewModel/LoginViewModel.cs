using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using TicketManagementSystem_Capstone.Repository;
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
    }

    private void Login()
    {

        // get user id by email.
        /*
        if ()
        {
            if ()
            {
                // Todo(M) - do the navigation differently 
                var view1 = App._host.Services.GetRequiredService<LoginView>();
                view1.Visibility = Visibility.Hidden;
                
                var view2 = App._host.Services.GetService<MainView>();
                view2.Show();
            }
        }
        else
        {
            
        }
        */
        // verify email and password match 
        // TODO - Need to crypt/hash/salt passwords

        // if so LOG IN AND MOVE TO MainWindow

        // else print error

    }
}
