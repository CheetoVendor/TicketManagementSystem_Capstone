using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TicketManagementSystem_Capstone.Repository.Interfaces;
using TicketManagementSystem_Capstone.Models;

namespace TicketManagementSystem_Capstone.ViewModel
{
    public partial class CreateTicketViewModel : BaseViewModel
    {
        #region Props
        // Ticket info
        [ObservableProperty]
        public string _Title;

        [ObservableProperty]
        public string _Description;
        [ObservableProperty]
        public string _Status;
        [ObservableProperty]
        public string _Priority;
        [ObservableProperty]
        public string _AssignedTo;
        // Customer info
        [ObservableProperty]
        public string _CustomerName;
        [ObservableProperty]
        public string _Phone;
        [ObservableProperty]
        public string _Email;

        [ObservableProperty]
        public List<string> _Statuses = new List<string> { "Open", "Assigned", "In Progress",
            "Pending Customer", "On Hold", "Resolved", "Closed", "Reopened", "Cancelled", "Escalated"};
        [ObservableProperty]
        public List<string> _Priorities = new List<string> {"High", "Standard"};

        IUnitOfWork UnitOfWork { get; set; }
        #endregion
        public CreateTicketViewModel(IUnitOfWork unitOfWork)
        {
            // Init unit of work with DI 
            UnitOfWork = unitOfWork;

            // Get List of employees to assign to..

            // Set Commands
            ClearCommand = new RelayCommand(Clear);
            CreateTicketCommand = new RelayCommand(CreateTicket);

        }

        private void CreateTicket()
        {
            // Check if customer exists 

            // If customer doesnt exist add customer then ticket

            //else add ticket

            //UnitOfWork.Tickets.Add(new Ticket());
        }

        private void Clear()
        {
            Title = "";
            Description = "";
            Status = "";
            Priority = "";
            AssignedTo = "";
            CustomerName = "";
            Phone = "";
            Email = "";
        }

        public ICommand ClearCommand;
        public ICommand CreateTicketCommand;
    }
}
