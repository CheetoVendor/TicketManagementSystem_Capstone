using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TicketManagementSystem_Capstone.Data;

namespace TicketManagementSystem_Capstone.ViewModel
{
    public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty] 
        public string? _email; 

        [ObservableProperty]
        public string? _password;
        
        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login);
        }

        private void Login()
        {
            // get user id by email.

            // verify email and password match

            // if so LOG IN AND MOVE TO MainWindow

            // else print error
        }
    }
}
