﻿using TicketManagementSystem_Capstone.View;
using TicketManagementSystem_Capstone.View.Reports;
using TicketManagementSystem_Capstone.ViewModel;
using TicketManagementSystem_Capstone.ViewModel.Reports;

namespace TicketManagementSystem_Capstone.Services;

public interface IVVMS
{
    MainViewModel GetMainViewModel();
    MainView GetMainView();
    LoginView GetLoginView();
    LoginViewModel GetLoginViewModel();
    TicketControlView GetTicketControlView();
    TicketControlViewModel GetTicketControlViewModel();
    CreateNewTicketView GetCreateNewTicketView();
    CreateNewTicketViewModel GetCreateNewTicketViewModel();

    ArchiveTicketView GetArchiveTicketView();
    ArchiveTicketViewModel GetArchiveTicketViewModel();

    CustomerView GetCustomerView();
    CustomerViewModel GetCustomerViewModel();

    TicketTabControlView GetTicketTabControlView();
    IBaseTabViewModel GetTicketTabControlViewModel();

    CustomerTabControlView GetCustomerTabControlView();

    IBaseTabViewModel GetCustomerTabControlViewModel();

    CreateNewCustomerView GetCreateNewCustomerView();

    CreateNewCustomerViewModel GetCreateNewCustomerViewModel();

    ReportsTabControlView GetReportsTabControlView();

    IBaseTabViewModel GetReportsTabControlViewModel();

    AdministrationTabControlView GetAdministrationTabControlView();

    IBaseTabViewModel GetAdministrationTabControlViewModel();

    IBaseTabViewModel GetEmployeeViewModel();

    EmployeeView GetEmployeeView();

    IBaseTabViewModel GetCreateEmployeeViewModel();

    CreateEmployeeView GetCreateNewEmployeeView();

    TicketCompletionTimeView GetTicketCompletionTimeView();

    TicketCompletionTimeViewModel GetTicketCompletionTimeViewModel();
}
