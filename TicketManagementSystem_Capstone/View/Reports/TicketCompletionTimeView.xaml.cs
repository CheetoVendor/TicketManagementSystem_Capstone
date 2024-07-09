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
using TicketManagementSystem_Capstone.ViewModel.Reports;

namespace TicketManagementSystem_Capstone.View.Reports
{
    /// <summary>
    /// Interaction logic for TicketCompletionTimeView.xaml
    /// </summary>
    public partial class TicketCompletionTimeView : UserControl
    {
        public TicketCompletionTimeView(TicketCompletionTimeViewModel vm)
        {
            DataContext = vm;
            InitializeComponent();
        }
    }
}
