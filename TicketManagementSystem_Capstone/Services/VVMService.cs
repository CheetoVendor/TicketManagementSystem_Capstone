using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TicketManagementSystem_Capstone.View;
using TicketManagementSystem_Capstone.ViewModel;
using TicketManagementSystem_Capstone.ViewModel.Administration;

namespace TicketManagementSystem_Capstone.Services
{
    public class VVMService : IVVMS
    {
        private readonly IServiceProvider _serviceProvider;

        public VVMService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T GetService<T>()
        {
            return _serviceProvider.GetService<T>();
        }

        public ArchiveTicketView GetArchiveTicketView()
        {
            return GetService<ArchiveTicketView>();
        }

        public ArchiveTicketViewModel GetArchiveTicketViewModel()
        {
            return GetService<ArchiveTicketViewModel>();
        }

        public CreateNewTicketView GetCreateNewTicketView()
        {
           return GetService<CreateNewTicketView>();
        }

        public CreateNewTicketViewModel GetCreateNewTicketViewModel()
        {
            return GetService<CreateNewTicketViewModel>();
        }

        public CustomerTabControlView GetCustomerTabControlView()
        {
            return GetService<CustomerTabControlView>();
        }

        public IBaseTabViewModel GetCustomerTabControlViewModel()
        {
            return GetService<CustomerTabControlViewModel>();
        }

        public CustomerView GetCustomerView()
        {
            return GetService<CustomerView>();
        }

        public CustomerViewModel GetCustomerViewModel()
        {
            return GetService<CustomerViewModel>();
        }

        public LoginView GetLoginView()
        {
            return GetService<LoginView>();
        }

        public LoginViewModel GetLoginViewModel()
        {
           return GetService<LoginViewModel>();
        }

        public MainView GetMainView()
        {
            return GetService<MainView>();
        }

        public MainViewModel GetMainViewModel()
        {
            return GetService<MainViewModel>();
        }

        public TicketControlView GetTicketControlView()
        {
            return GetService<TicketControlView>();
        }

        public TicketControlViewModel GetTicketControlViewModel()
        {
            return GetService<TicketControlViewModel>();
        }

        public TicketTabControlView GetTicketTabControlView()
        {
            return GetService<TicketTabControlView>();
        }

        public IBaseTabViewModel GetTicketTabControlViewModel()
        {
            return GetService<TicketTabControlViewModel>();
        }

        public CreateNewCustomerView GetCreateNewCustomerView()
        {
            return GetService<CreateNewCustomerView>();
        }

        public CreateNewCustomerViewModel GetCreateNewCustomerViewModel()
        {
            return GetService<CreateNewCustomerViewModel>();
        }

        public ReportsTabControlView GetReportsTabControlView()
        {
            return GetService<ReportsTabControlView>();
        }

        public IBaseTabViewModel GetReportsTabControlViewModel()
        {
            return GetService<ReportsTabControlViewModel>();
        }

        public AdministrationTabControlView GetAdministrationTabControlView()
        {
            return GetService<AdministrationTabControlView>();  
        }

        public IBaseTabViewModel GetAdministrationTabControlViewModel()
        {
            return GetService<AdministrationTabControlViewModel>();
        }

        public IBaseTabViewModel GetEmployeeViewModel()
        {
            return GetService<EmployeeViewModel>();
        }

        public EmployeeView GetEmployeeView()
        {
            return GetService<EmployeeView>();
        }

        public IBaseTabViewModel GetCreateEmployeeViewModel()
        {
            return GetService<CreateEmployeeViewModel>();
        }

        public CreateEmployeeView GetCreateNewEmployeeView()
        {
            return GetService<CreateEmployeeView>();
        }
    }
}
