using CommunityToolkit.Mvvm.ComponentModel;
using TicketManagementSystem_Capstone.Services;

namespace TicketManagementSystem_Capstone.ViewModel
{
    public partial class MainViewModel : BaseViewModel
    {
        #region Props
        private IVVMS _viewViewModelService;

        [ObservableProperty]
        public BaseViewModel? _CurrentTab;

        [ObservableProperty]
        public object? _CurrentTabView;

        [ObservableProperty]
        public int _Index;

        #endregion

        #region Ctors
        public MainViewModel(VVMService viewViewModelService)
        {
            _viewViewModelService = viewViewModelService;

            CurrentTab = _viewViewModelService.GetTicketControlViewModel();
            CurrentTabView = _viewViewModelService.GetTicketControlView();
        }
        #endregion



        // Used to change view/viewmodel when tab is changed
        partial void OnIndexChanged(int oldValue, int newValue)
        {
            switch (Index)
            {
                case 0:
                    CurrentTab = _viewViewModelService.GetTicketControlViewModel();
                    CurrentTabView = _viewViewModelService.GetTicketControlView();
                    break;
                case 1:
                    CurrentTab = _viewViewModelService.GetCreateNewTicketViewModel();
                    CurrentTabView = _viewViewModelService.GetCreateNewTicketView();
                    break;
                case 2:
                    CurrentTab = _viewViewModelService.GetArchiveTicketViewModel();
                    CurrentTabView = _viewViewModelService.GetArchiveTicketView();
                    break;
                default:
                    break;
            }
        }
    }
}
