using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TicketManagementSystem_Capstone.Models;
using TicketManagementSystem_Capstone.Repository.Interfaces;

namespace TicketManagementSystem_Capstone.ViewModel;

public partial class ArchiveTicketViewModel : BaseViewModel
{
    [ObservableProperty]
    public ObservableCollection<Ticket>? _Tickets;

    [ObservableProperty]
    public Ticket? _SelectedTicket;

    [ObservableProperty]
    public Customer? _SelectedCustomer;

    IUnitOfWork UnitOfWork { get; set; }

    public ICommand ReopenSelectedTicketCommand { get; }

    public ArchiveTicketViewModel(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
        Tickets = new ObservableCollection<Ticket>(UnitOfWork.Tickets.GetClosed());

        ReopenSelectedTicketCommand = new RelayCommand(ReopenSelectedTicket);
    }

    private void ReopenSelectedTicket()
    {
        if(SelectedTicket != null)
        {
            SelectedTicket.Status = "Open";
            UnitOfWork.Tickets.Update(SelectedTicket);
            UnitOfWork.Commit();
        }

        SelectedTicket = null;
        SelectedCustomer = null;

        Tickets = new ObservableCollection<Ticket>(UnitOfWork.Tickets.GetClosed());
    }

    partial void OnSelectedTicketChanged(Ticket value)
    {
        if(value != null)
        {
            SelectedCustomer = UnitOfWork.Customers.GetCustomerById(value.Customer_Id);
        }
        
    }
}
