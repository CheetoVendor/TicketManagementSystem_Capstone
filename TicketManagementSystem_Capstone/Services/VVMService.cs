using Microsoft.Extensions.DependencyInjection;
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

        public ArchiveTicketView GetArchiveTicketView()
        {
            var view = (ArchiveTicketView)_host.Services.GetService(typeof(ArchiveTicketView));
            return view;
        }

        public ArchiveTicketViewModel GetArchiveTicketViewModel()
        {
            var viewModel = (ArchiveTicketViewModel)_host.Services.GetService(typeof(ArchiveTicketViewModel));
            return viewModel;
        }

        public CreateNewTicketView GetCreateNewTicketView()
        {
           var view = (CreateNewTicketView)_host.Services.GetService(typeof(CreateNewTicketView));
            return view;
        }

        public CreateNewTicketViewModel GetCreateNewTicketViewModel()
        {
            var viewModel = (CreateNewTicketViewModel)_host.Services.GetService(typeof(CreateNewTicketViewModel));
            return viewModel;
        }

        public CustomerView GetCustomerView()
        {
            var view = (CustomerView)_host.Services.GetService(typeof(CustomerView));
            return view;
        }

        public CustomerViewModel GetCustomerViewModel()
        {
            var viewModel = (CustomerViewModel)_host.Services.GetService(typeof(CustomerViewModel));
            return viewModel;
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
