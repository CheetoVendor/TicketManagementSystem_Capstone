using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using TicketManagementSystem_Capstone.ViewModel;

namespace TicketManagementSystem_Capstone.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView(MainViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }

        private void DockPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ButtonState == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
