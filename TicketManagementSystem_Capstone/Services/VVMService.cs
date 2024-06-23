using Microsoft.Extensions.Hosting;
using TicketManagementSystem_Capstone.View;
using TicketManagementSystem_Capstone.ViewModel;

namespace TicketManagementSystem_Capstone.Services
{
    public class VVMService : IVVMS
    {
        private Dictionary<Type, Type> viewViewModels = new Dictionary<Type, Type>();

        private IHost _host;
        // Todo edit later to throw into dictionary and then edit methods to pull from view model
        public VVMService(IHost host)
        {
            _host = host;
        }

        public LoginView GetLoginView()
        {
            var view = (LoginView)_host.Services.GetService(typeof(LoginView));
            return view;
        }

        public LoginViewModel GetLoginViewModel()
        {
           var viewModel = (LoginViewModel)_host.Services.GetService(typeof(LoginViewModel));
            return viewModel;
        }

        public MainView GetMainView()
        {
            var view = (MainView)_host.Services.GetService(typeof(MainView));
            return view;
        }

        public MainViewModel GetMainViewModel()
        {
            var viewModel = (MainViewModel)_host.Services.GetService(typeof(MainViewModel));
            return viewModel;
        }

        public TicketControlView GetTicketControlView()
        {
            var view = (TicketControlView)_host.Services.GetService(typeof (TicketControlView));
            return view;
        }

        public TicketControlViewModel GetTicketControlViewModel()
        {
            var viewModel = (TicketControlViewModel)_host.Services.GetService(typeof(TicketControlViewModel));
            return viewModel;
        }
    }
}
