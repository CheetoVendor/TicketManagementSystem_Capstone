using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows;
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

        [ObservableProperty]
        public List<string> _Groups = new List<string> { "Tech Support", "Maintenance Team" };

        IUnitOfWork UnitOfWork { get; set; }

        public ICommand UpdateSelectedTicketCommand { get; }
        public ICommand DeleteSelectedTicketCommand { get; }
        public ICommand ShowOpenTicketsCommand { get; }
        public ICommand ShowAssignedTicketsCommand { get; }

        public TicketControlViewModel(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            UpdateTickets();
            SelectedTicket = Tickets[0];

            UpdateSelectedTicketCommand = new RelayCommand(UpdateSelectedTicket);
            DeleteSelectedTicketCommand = new RelayCommand(DeleteSelectedTicket);
            ShowOpenTicketsCommand = new RelayCommand(ShowOpenTickets);
            ShowAssignedTicketsCommand = new RelayCommand(ShowAssignedTickets);
        }

        private void ShowAssignedTickets()
        {
            throw new NotImplementedException();
        }

        private void ShowOpenTickets()
        {
            Tickets = new ObservableCollection<Ticket>(UnitOfWork.Tickets.GetOpen());
        }

        private void DeleteSelectedTicket()
        {
            if(MessageBox.Show("Are you sure you want to delete the selected ticket?", "Delete Ticket?", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
            {
                UnitOfWork.Tickets.Delete(SelectedTicket);
            }  
        }

        private void UpdateSelectedTicket()
        {
            // Check for nulls / whitespaces
        }

        private void UpdateTickets()
        {
            Tickets = new ObservableCollection<Ticket>(UnitOfWork.Tickets.GetOpen());
        }

        // Updates customer depending on ticket selected
        partial void OnSelectedTicketChanged(Ticket value)
        {
            SelectedCustomer = UnitOfWork.Customers.GetCustomerById(value.Customer_Id);
        }
    }
}
