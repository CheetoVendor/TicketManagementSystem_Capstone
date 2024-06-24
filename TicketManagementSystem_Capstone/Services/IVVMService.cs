﻿using TicketManagementSystem_Capstone.View;
using TicketManagementSystem_Capstone.ViewModel;

namespace TicketManagementSystem_Capstone.Services
{
    public interface IVVMS
    {
        MainViewModel GetMainViewModel();
        MainView GetMainView();
        LoginView GetLoginView();
        LoginViewModel GetLoginViewModel();
        TicketControlView GetTicketControlView();
        TicketControlViewModel GetTicketControlViewModel();
        CreateTicketView GetCreateTicketView();
        CreateTicketViewModel GetCreateTicketViewModel();
    }
}