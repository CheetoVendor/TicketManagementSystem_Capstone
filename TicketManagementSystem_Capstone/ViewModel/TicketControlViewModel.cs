using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using TicketManagementSystem_Capstone.Models;
using TicketManagementSystem_Capstone.Repository.Interfaces;
using TicketManagementSystem_Capstone.Services;

namespace TicketManagementSystem_Capstone.ViewModel;

public partial class TicketControlViewModel : BaseViewModel
{
    [ObservableProperty]
    public ObservableCollection<Ticket>? _Tickets;

    [ObservableProperty]
    public Ticket? _SelectedTicket;

    [ObservableProperty]
    public Customer? _SelectedCustomer;

    public string? _filterString = "All";

    #region Ticket Fields
    [ObservableProperty]
    public string? _Title;

    [ObservableProperty]
    public string? _Description;

    [ObservableProperty]
    public string? _Status;

    [ObservableProperty]
    public string? _AssignedTo;
    #endregion

    #region Combo Box Options
    [ObservableProperty]
    public List<string>? _Groups = new List<string> { "", "Tech Support", "Maintenance Team" };
    [ObservableProperty]
    public List<string>? _Statuses = new List<string> {"", "Open", "Assigned", "In Progress", "Closed"};
    [ObservableProperty]
    public List<string>? _Priorities = new List<string> { "", "High", "Standard" };
    #endregion

    private IUnitOfWork UnitOfWork { get; set; }
    private UserService _userService;
    public ICommand UpdateSelectedTicketCommand { get; }
    public ICommand DeleteSelectedTicketCommand { get; }
    public ICommand FilterTicketsCommand { get; }

    public TicketControlViewModel(IUnitOfWork unitOfWork, UserService userService)
    {
        UnitOfWork = unitOfWork;
        _userService = userService;

        // Init Commands
        UpdateSelectedTicketCommand = new RelayCommand(UpdateSelectedTicket);
        DeleteSelectedTicketCommand = new RelayCommand(DeleteSelectedTicket);
        FilterTicketsCommand = new RelayCommand<string>(FilterTickets);

        Tickets = new ObservableCollection<Ticket>(UnitOfWork.Tickets.FindAll());
    }

    private void FilterTickets(string? value)
    {
        ClearTicketInformation();
        SelectedTicket = null;
        switch (value)
        {
            case "All":
                Tickets = new ObservableCollection<Ticket>(UnitOfWork.Tickets.FindAll());
                break;
            case "Open":
                Tickets = new ObservableCollection<Ticket>(UnitOfWork.Tickets.GetOpen());
                break;
            case "Assigned":
                Tickets = new ObservableCollection<Ticket>(UnitOfWork.Tickets.GetAssigned(_userService.User.Team));
                break;
        }

        _filterString = value;
    }

    // Asks user if they want to delete the ticket. 
    private void DeleteSelectedTicket()
    {
        if(SelectedTicket == null)
        {
            return;
        }

        if (MessageBox.Show("Are you sure you want to delete the selected ticket?", "Delete Ticket?",
            MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
        {
            UnitOfWork.Tickets.Delete(SelectedTicket);
            UnitOfWork.Commit();
            FilterTickets(_filterString);
        }
    }

    // Updates the ticket, adds to db and saves changes.
    private void UpdateSelectedTicket()
    {
        // If changes are different from initial value
        // This stops it from updating pointlessly
        if (ChangesMade())
        {
            if (SelectedTicket != null)
            {
                // Apply changes on fields to ticket
                SelectedTicket.Title = Title;
                SelectedTicket.Description = Description;
                SelectedTicket.Status = Status;
                SelectedTicket.Assigned_To = AssignedTo;
                SelectedTicket.Updated_Date = DateTime.Now;

                // Update ticket and update tickets collection
                UnitOfWork.Tickets.Update(SelectedTicket);
                UnitOfWork.Commit();
                FilterTickets(_filterString);
            }
        }
        
    }

    // Updates customer and ticket info depending on ticket selected
    partial void OnSelectedTicketChanged(Ticket value)
    {
        if (value != null)
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

    private void ClearTicketInformation()
    {
        Title = "";
        Description = "";
        Status = "";
        AssignedTo = "";
    }

    public bool ChangesMade()
    {
        if(SelectedTicket.Title != Title ||
            SelectedTicket.Description != Description ||
            SelectedTicket.Status != Status ||
            SelectedTicket.Assigned_To != AssignedTo)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
