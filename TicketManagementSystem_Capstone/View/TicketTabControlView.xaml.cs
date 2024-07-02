using System.Drawing;
using System.Windows.Controls;
using TicketManagementSystem_Capstone.ViewModel;

namespace TicketManagementSystem_Capstone.View;

/// <summary>
/// Interaction logic for TicketTabControlView.xaml
/// </summary>
public partial class TicketTabControlView : UserControl
{
    public TicketTabControlView(TicketTabControlViewModel vm)
    {
        DataContext = vm;
        InitializeComponent();
    }
}
