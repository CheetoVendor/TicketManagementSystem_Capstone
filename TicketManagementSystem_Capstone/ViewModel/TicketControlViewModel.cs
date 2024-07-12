using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
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

    [ObservableProperty]
    public string? _SearchText;

    public string? _filterString = "All";

    #region Ticket Fields
    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required]
    public string? _Title;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required]
    public string? _Description;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required]
    public string? _Status;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required]
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

    public ICommand SearchCommand { get; }

    public TicketControlViewModel(IUnitOfWork unitOfWork, UserService userService)
    {
        UnitOfWork = unitOfWork;
        _userService = userService;

        // Init Commands
        UpdateSelectedTicketCommand = new RelayCommand(UpdateSelectedTicket);
        DeleteSelectedTicketCommand = new RelayCommand(DeleteSelectedTicket);
        FilterTicketsCommand = new RelayCommand<string>(FilterTickets);
        SearchCommand = new RelayCommand(Search);
        Tickets = new ObservableCollection<Ticket>(UnitOfWork.Tickets.FindAll());
    }

    private void Search()
    {
        ClearTicketInformation();
        ClearErrors();
        if(int.TryParse(SearchText, out int id))
        {
            SelectedTicket = Tickets.FirstOrDefault(t => t.Id == id);
            if(SelectedTicket == null)
            {
                MessageBox.Show("No ticket was found by that id.");
            }
        }
        else
        {
            Tickets = new ObservableCollection<Ticket>(UnitOfWork.Tickets.SearchTickets(SearchText));
        }
        
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
        ClearErrors();
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
        
        if (SelectedTicket != null)
        {
            // If changes are different from initial value
            // This stops it from updating pointlessly
            if (ChangesMade())
            {
                // Makes sure values arent empty
                ValidateAllProperties();
                if (!HasErrors)
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
                else
                {
                    MessageBox.Show("The red fields are required.");
                }
            }
            else
            {
                MessageBox.Show("No changes were made to the ticket to update.");
            }
        }
        else
        {
            MessageBox.Show("A ticket hasn't been selected to edit.");
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
