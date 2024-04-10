using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TicketManagementSystem_Capstone.Data;
using TicketManagementSystem_Capstone.Repository;
using TicketManagementSystem_Capstone.Repository.Interfaces;

namespace TicketManagementSystem_Capstone.ViewModel
{
    public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty] 
        public string? _email; 

        [ObservableProperty]
        public string? _password;

        [ObservableProperty] 
        public string? _errorMessage;


        public ICommand LoginCommand { get; }

        private IUnitOfWork _unitOfWork;
        private IUserRepository _userRepository;

        public LoginViewModel(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            this._unitOfWork = unitOfWork;
            this._userRepository = userRepository;
            LoginCommand = new RelayCommand(Login);
        }

        private void Login()
        {
            // get user id by email.
            if (_userRepository.EmailExists(Email))
            {
                if (_userRepository.IsLoginCorrect(Email, Password))
                {
                    
                }
            }
            else
            {
                
            }
            // verify email and password match 
            // TODO - Need to crypt/hash/salt passwords

            // if so LOG IN AND MOVE TO MainWindow

            // else print error
        }
    }
}
