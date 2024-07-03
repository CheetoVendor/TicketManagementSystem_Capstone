using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystem_Capstone.Repository;
using TicketManagementSystem_Capstone.Repository.Interfaces;
using TicketManagementSystem_Capstone.Services;

namespace TicketManagementSystem_Capstone.ViewModel
{
    public partial class CustomerTabControlViewModel : BaseViewModel, IBaseTabViewModel
    {
        public string TabName { get; set; } = "Customers";

        [ObservableProperty]
        public object? _SelectedTab;

        [ObservableProperty]
        public object? _SelectedTabView;

        [ObservableProperty]
        public int _TabIndex;

        IUnitOfWork _UnitOfWork { get; set; }
        IVVMS _ViewViewModelService { get; set; }

        public CustomerTabControlViewModel(IUnitOfWork unitOfWork, VVMService service)
        {
            _UnitOfWork = unitOfWork;
            _ViewViewModelService = service;

            SelectedTab = _ViewViewModelService.GetCustomerViewModel();
            SelectedTabView = _ViewViewModelService.GetCustomerView();
        }

        partial void OnTabIndexChanged(int value)
        {
            switch (value)
            {
                case 0:
                    SelectedTab = _ViewViewModelService.GetCustomerViewModel();
                    SelectedTabView = _ViewViewModelService.GetCustomerView();
                    break;
                case 1:
                    //SelectedTab = _ViewViewModelService.GetCustomerViewModel();
                    //SelectedTabView = _ViewViewModelService.GetCustomerView();
                    break;
                default:

                    break;
            }
        }
    }
}
