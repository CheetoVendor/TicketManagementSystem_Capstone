using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystem_Capstone.ViewModel
{
    public partial class AdministrationTabControlViewModel : BaseViewModel , IBaseTabViewModel
    {
        public string TabName { get; set; } = "Administration";
    }
}
