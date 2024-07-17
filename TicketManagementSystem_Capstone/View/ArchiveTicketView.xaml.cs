using System.Windows.Controls;
using TicketManagementSystem_Capstone.ViewModel;

namespace TicketManagementSystem_Capstone.View
{
    /// <summary>
    /// Interaction logic for ArchiveTicketView.xaml
    /// </summary>
    public partial class ArchiveTicketView : UserControl
    {
        public ArchiveTicketView(ArchiveTicketViewModel vm)
        {
            DataContext = vm;
            InitializeComponent();
        }
    }
}
