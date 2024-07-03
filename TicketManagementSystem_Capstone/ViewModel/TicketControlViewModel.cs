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
        public Customer? _SelectedCustomer;

        #region Ticket Fields
        [ObservableProperty]
        public string _Title;

        [ObservableProperty]
        public string _Description;

        [ObservableProperty]
        public string _Status;

        [ObservableProperty]
        public string _AssignedTo;

        #endregion

        #region Combo Box Options
        [ObservableProperty]
        public List<string> _Groups = new List<string> { "Tech Support", "Maintenance Team" };
        [ObservableProperty]
        public List<string> _Statuses = new List<string> {"", "Open", "Assigned", "In Progress",
        "Pending Customer", "On Hold", "Resolved", "Closed"};
        [ObservableProperty]
        public List<string> _Priorities = new List<string> { "", "High", "Standard" };
        #endregion

        IUnitOfWork UnitOfWork { get; set; }

        public ICommand UpdateSelectedTicketCommand { get; }
        public ICommand DeleteSelectedTicketCommand { get; }
        public ICommand ShowOpenTicketsCommand { get; }
        public ICommand ShowAssignedTicketsCommand { get; }

        public TicketControlViewModel(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            ShowOpenTickets();
            SelectedTicket = Tickets.FirstOrDefault();

            // Init Commands
            UpdateSelectedTicketCommand = new RelayCommand(UpdateSelectedTicket);
            DeleteSelectedTicketCommand = new RelayCommand(DeleteSelectedTicket);
            ShowOpenTicketsCommand = new RelayCommand(ShowOpenTickets);
            ShowAssignedTicketsCommand = new RelayCommand(ShowAssignedTickets);
        }

        private void ShowAssignedTickets()
        {
            Tickets = new ObservableCollection<Ticket>(UnitOfWork.Tickets.GetAssigned("Maintenance Team")); // Todo(L) - change to current users team for argument
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
                UnitOfWork.Commit();
                ShowOpenTickets(); // TODO - Change to update depending on radio box selected
            }
        }

        // Updates the ticket, adds to db and saves changes.
        private void UpdateSelectedTicket()
        {
            // Apply changes on fields to ticket
            SelectedTicket.Title = Title;
            SelectedTicket.Description = Description;
            SelectedTicket.Status = Status;
            SelectedTicket.Assigned_To = AssignedTo;
            SelectedTicket.Updated_Date = DateTime.Now;


            UnitOfWork.Tickets.Update(SelectedTicket);
            UnitOfWork.Commit();
            ShowOpenTickets();
        }

        // Updates customer depending on ticket selected
        partial void OnSelectedTicketChanged(Ticket value)
        {
            if(value != null)
            {
                SelectedCustomer = UnitOfWork.Customers.GetCustomerById(value.Customer_Id);


                // Update Ticket Fields
                Title = value.Title;
                Description = value.Description;
                Status = value.Status;
                AssignedTo = value.Assigned_To;
            }
            else
            {
                SelectedCustomer = null;
            }
        }
    }
}
