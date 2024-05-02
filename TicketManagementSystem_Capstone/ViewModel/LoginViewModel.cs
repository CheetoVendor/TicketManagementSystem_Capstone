using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Input;
using TicketManagementSystem_Capstone.Repository;
using TicketManagementSystem_Capstone.Repository.Interfaces;
using TicketManagementSystem_Capstone.View;

namespace TicketManagementSystem_Capstone.ViewModel
{
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

            this._unitOfWork = unitOfWork as UnitOfWork;
            LoginCommand = new RelayCommand(Login);
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
}
