using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;
using TicketManagementSystem_Capstone.Services;
using TicketManagementSystem_Capstone.View;

namespace TicketManagementSystem_Capstone.ViewModel
{
    public partial class MainViewModel : BaseViewModel
    {
        #region Props
        private IVVMS _viewViewModelService;
        private BaseViewModel? _currentTab;
        public BaseViewModel? CurrentTab
        {
            get => _currentTab;
            set
            {
                if(_currentTab != value)
                {
                    _currentTab = value;
                    OnPropertyChanged(nameof(CurrentTab));
                    OnPropertyChanged(nameof(CurrentTabView));
                }
            }
        }
        
        // Prop for the view
        public object? CurrentTabView 
        { 
            get
            {
                if(_currentTab != null && viewModelViewMap.ContainsKey(_currentTab.GetType()))
                {
                    var viewType = viewModelViewMap[_currentTab.GetType()];
                    // get host to return the view
                    var view = _viewViewModelService.GetTicketControlView();
                    return view;
                }
                return null;
            } 
        }

        // Dictionary to map view and view model
        public Dictionary<Type, Type> viewModelViewMap = new Dictionary<Type, Type>
        {
            {typeof(LoginViewModel), typeof(LoginView)},
            {typeof(TicketControlViewModel), typeof(TicketControlView) }
        };
        #endregion

        #region Ctors
        public MainViewModel(VVMService viewViewModelService)
        {
            _viewViewModelService = viewViewModelService;

            CurrentTab = _viewViewModelService.GetTicketControlViewModel();

            //Set Commands
            ChangeViewCommand = new RelayCommand(ChangeView);
        }
        #endregion

        #region Commands
        public ICommand ChangeViewCommand { get; }
        

        
        public void ChangeView()
        {
            
        }
        #endregion
    }
}
