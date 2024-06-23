using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TicketManagementSystem_Capstone.Models;
using TicketManagementSystem_Capstone.Repository.Interfaces;

namespace TicketManagementSystem_Capstone.ViewModel
{
    public partial class TicketControlViewModel : BaseViewModel
    {
        [ObservableProperty]
        public ObservableCollection<Ticket> _Tickets;

        [ObservableProperty]
        public Ticket _SelectedTicket;

        [ObservableProperty]
        public Customer _SelectedCustomer;

        IUnitOfWork UnitOfWork { get; set; }
        public TicketControlViewModel(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            UpdateTickets();
            SelectedTicket = Tickets[0];
        }

        private void UpdateTickets()
        {
            Tickets = new ObservableCollection<Ticket>(UnitOfWork.Tickets.GetActive());
        }
    }
}
