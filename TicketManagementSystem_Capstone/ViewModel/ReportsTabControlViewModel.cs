using CommunityToolkit.Mvvm.ComponentModel;
using TicketManagementSystem_Capstone.Services;

namespace TicketManagementSystem_Capstone.ViewModel;

public partial class ReportsTabControlViewModel : BaseViewModel , IBaseTabViewModel
{
    public string TabName { get; set; } = "Reports Tab";

    private IVVMS _viewViewModelService;

    [ObservableProperty]
    public object? _CurrentTab;

    [ObservableProperty]
    public object? _CurrentTabView;

    public ReportsTabControlViewModel(VVMService viewViewModelService)
    {
        _viewViewModelService = viewViewModelService;

        CurrentTab = _viewViewModelService.GetTicketCompletionTimeViewModel();
        CurrentTabView = _viewViewModelService.GetTicketCompletionTimeView();
    }

    
}
