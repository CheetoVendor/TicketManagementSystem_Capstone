using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using TicketManagementSystem_Capstone.Services;

namespace TicketManagementSystem_Capstone.ViewModel;

public partial class MainViewModel : BaseViewModel
{
    private IVVMS _viewViewModelService;

    [ObservableProperty]
    public object? _CurrentTab;

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

    private void ChangeView(string? tab)
    {
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

                break;
            case "Administration":

                break;
            default:
                break;
        }
    }




}
