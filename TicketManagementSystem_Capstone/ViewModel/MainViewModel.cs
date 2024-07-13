using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
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
    [ObservableProperty]
    public bool? _UserIsAdmin;

    private UserService _userService;

    public ICommand ChangeViewCommand { get; }
    public ICommand ExitCommand { get; }
    public MainViewModel(VVMService viewViewModelService, UserService userService)
    {
        _viewViewModelService = viewViewModelService;
        _userService = userService;

        UserIsAdmin = _userService.User.Admin == 1 ? true : false;

        CurrentTab = _viewViewModelService.GetTicketTabControlViewModel();
        CurrentTabView = _viewViewModelService.GetTicketTabControlView();

        ChangeViewCommand = new RelayCommand<string>(ChangeView);
        ExitCommand = new RelayCommand(Exit);
    }

    private void Exit()
    {
        Application.Current.Shutdown();
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
