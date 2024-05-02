using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Web.WebView2.Core.Raw;
using TicketManagementSystem_Capstone.View;

namespace TicketManagementSystem_Capstone.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public BaseViewModel? CurrentWindow { get; set; }
        public MainViewModel()
        {
            CurrentWindow = App._host.Services.GetRequiredService<LoginViewModel>();
        }
    }
}
