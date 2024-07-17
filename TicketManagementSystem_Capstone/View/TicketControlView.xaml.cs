using System.Windows.Controls;
using TicketManagementSystem_Capstone.ViewModel;

namespace TicketManagementSystem_Capstone.View
{
    /// <summary>
    /// Interaction logic for TicketControlView.xaml
    /// </summary>
    public partial class TicketControlView : UserControl
    {
        public TicketControlView(TicketControlViewModel vm)
        {
            DataContext = vm;
            InitializeComponent();
        }
    }
}
