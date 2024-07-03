using System.Windows.Controls;
using TicketManagementSystem_Capstone.ViewModel;

namespace TicketManagementSystem_Capstone.View;

/// <summary>
/// Interaction logic for CreateNewCustomerView.xaml
/// </summary>
public partial class CreateNewCustomerView : UserControl
{
    public CreateNewCustomerView(CreateNewCustomerViewModel vm)
    {
        DataContext = vm;
        InitializeComponent();
    }
}
