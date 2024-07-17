using CommunityToolkit.Mvvm.ComponentModel;
using TicketManagementSystem_Capstone.Repository.Interfaces;
using TicketManagementSystem_Capstone.Services;

namespace TicketManagementSystem_Capstone.ViewModel;

public partial class TicketTabControlViewModel : BaseViewModel, IBaseTabViewModel
{
    public string TabName { get; set; } = "Tickets";

    [ObservableProperty]
    public object? _SelectedTab;

    [ObservableProperty]
    public object? _SelectedTabView;

    [ObservableProperty]
    public int _TabIndex;

    private IVVMS _ViewViewModelService { get; set; }


    public TicketTabControlViewModel(VVMService viewViewmodelService)
    {
        _ViewViewModelService = viewViewmodelService;

        SelectedTab = _ViewViewModelService.GetTicketControlViewModel();
        SelectedTabView = _ViewViewModelService.GetTicketControlView();
    }


    // Changes view and view model via selected tab index.
    partial void OnTabIndexChanged(int value)
    {
        switch (value)
        {
            case 0:
                SelectedTab = _ViewViewModelService.GetTicketTabControlViewModel();
                SelectedTabView = _ViewViewModelService.GetTicketControlView();
                break;
            case 1:
                SelectedTab = _ViewViewModelService.GetCreateNewTicketViewModel();
                SelectedTabView = _ViewViewModelService.GetCreateNewTicketView();
                break;
            case 2:
                SelectedTab = _ViewViewModelService.GetArchiveTicketViewModel();
                SelectedTabView = _ViewViewModelService.GetArchiveTicketView();
                break;
            default:
                break;
        }
    }
}
