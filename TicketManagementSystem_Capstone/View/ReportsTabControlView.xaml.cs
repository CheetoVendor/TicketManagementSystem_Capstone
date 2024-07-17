using System.Windows.Controls;
using TicketManagementSystem_Capstone.ViewModel;

namespace TicketManagementSystem_Capstone.View;

/// <summary>
/// Interaction logic for ReportsTabControlView.xaml
/// </summary>
public partial class ReportsTabControlView : UserControl
{
    public ReportsTabControlView(ReportsTabControlViewModel vm)
    {
        DataContext = vm;
        InitializeComponent();
    }
}
