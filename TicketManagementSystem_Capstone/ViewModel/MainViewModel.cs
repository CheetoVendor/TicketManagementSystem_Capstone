using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using TicketManagementSystem_Capstone.Services;

namespace TicketManagementSystem_Capstone.ViewModel;

public partial class MainViewModel : BaseViewModel
{
    private IVVMS _viewViewModelService;

    [ObservableProperty]
    public IBaseTabViewModel _CurrentTab;

    [ObservableProperty]
    public object? _CurrentTabView;

    [ObservableProperty]
    public int _Index = 0;

    public ICommand ChangeViewCommand { get; }

    public MainViewModel(VVMService viewViewModelService)
    {
        _viewViewModelService = viewViewModelService;

        CurrentTab = _viewViewModelService.GetTicketTabControlViewModel();
        CurrentTabView = _viewViewModelService.GetTicketTabControlView();

        ChangeViewCommand = new RelayCommand<string>(ChangeView);
    }

    // Changes the View and View model whenever a tab is selected.
    private void ChangeView(string? tab)
    {
        // Used so it doesnt refresh the tab if you click on the same one.
        if (CurrentTab.TabName == tab)
        {
            return;
        }

        switch (tab)
        {
            case "Tickets":
                CurrentTab = _viewViewModelService.GetTicketTabControlViewModel();
                CurrentTabView = _viewViewModelService.GetTicketTabControlView();
                break;
            case "Customers":
                CurrentTab = _viewViewModelService.GetCustomerTabControlViewModel();
                CurrentTabView = _viewViewModelService.GetCustomerTabControlView();
                break;
            case "Reports":
                CurrentTab = _viewViewModelService.GetReportsTabControlViewModel();
                CurrentTabView = _viewViewModelService.GetReportsTabControlView();
                break;
            case "Administration":
                CurrentTab = _viewViewModelService.GetAdministrationTabControlViewModel();
                CurrentTabView = _viewViewModelService.GetAdministrationTabControlView();
                break;
            default:
                break;
        }
    }
}
