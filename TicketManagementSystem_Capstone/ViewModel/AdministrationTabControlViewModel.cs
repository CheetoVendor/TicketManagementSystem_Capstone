using CommunityToolkit.Mvvm.ComponentModel;
using TicketManagementSystem_Capstone.Services;

namespace TicketManagementSystem_Capstone.ViewModel;

public partial class AdministrationTabControlViewModel : BaseViewModel, IBaseTabViewModel
{
    public string TabName { get; set; } = "Administration";

    [ObservableProperty]
    public int _TabIndex;

    [ObservableProperty]
    public object? _CurrentTab;

    [ObservableProperty]
    public object? _CurrentTabView;

    public IVVMS _viewViewModelSerivce;

    public AdministrationTabControlViewModel(VVMService viewViewModelService)
    {
        _viewViewModelSerivce = viewViewModelService;


        CurrentTab = _viewViewModelSerivce.GetEmployeeViewModel();
        CurrentTabView = _viewViewModelSerivce.GetEmployeeView();
    }

    partial void OnTabIndexChanged(int value)
    {

        switch (value)
        {
            case 0: // Employees
                CurrentTab = _viewViewModelSerivce.GetEmployeeViewModel();
                CurrentTabView = _viewViewModelSerivce.GetEmployeeView();
                break;

            case 1: // Add Employee
                CurrentTab = _viewViewModelSerivce.GetCreateEmployeeViewModel();
                CurrentTabView = _viewViewModelSerivce.GetCreateNewEmployeeView();
                break;

            default:

                break;
        }
    }

}
