using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TicketManagementSystem_Capstone.ViewModel;

namespace TicketManagementSystem_Capstone.View
{
    /// <summary>
    /// Interaction logic for CustomerTabControlView.xaml
    /// </summary>
    public partial class CustomerTabControlView : UserControl
    {
        public CustomerTabControlView(CustomerTabControlViewModel vm)
        {
            DataContext = vm;
            InitializeComponent();
        }
    }
}
