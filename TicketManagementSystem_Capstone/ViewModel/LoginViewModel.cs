using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Hosting;

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
            if(Email == "A" && Password == "A")
            {
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
            }
        }
    }
}
