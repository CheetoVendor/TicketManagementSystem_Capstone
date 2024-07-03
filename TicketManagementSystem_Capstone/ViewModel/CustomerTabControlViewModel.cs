using CommunityToolkit.Mvvm.ComponentModel;
using TicketManagementSystem_Capstone.Repository.Interfaces;
using TicketManagementSystem_Capstone.Services;

namespace TicketManagementSystem_Capstone.ViewModel;

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
                SelectedTab = _ViewViewModelService.GetCreateNewCustomerViewModel();
                SelectedTabView = _ViewViewModelService.GetCreateNewCustomerView();
                break;
            default:

                break;
        }
    }
}
