using TicketManagementSystem_Capstone.Services;

namespace TicketManagementSystem_Capstone.ViewModel;

public partial class ReportsTabControlViewModel : BaseViewModel , IBaseTabViewModel
{
    public string TabName { get; set; } = "Reports Tab";

    private IVVMS _viewViewModelService;

    public ReportsTabControlViewModel(VVMService viewViewModelService)
    {
        _viewViewModelService = viewViewModelService;
    }

    
}
