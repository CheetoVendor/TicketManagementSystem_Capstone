using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Input;
using TicketManagementSystem_Capstone.Models;
using TicketManagementSystem_Capstone.Repository.Interfaces;

namespace TicketManagementSystem_Capstone.ViewModel;

public partial class CustomerViewModel : BaseViewModel
{
    [ObservableProperty]
    public ObservableCollection<Customer>? _Customers;

    [ObservableProperty]
    public Customer? _SelectedCustomer;

    [ObservableProperty]
    public List<string> _Priorities = new List<string> { "", "High", "Standard" };

    #region Customer Fields
    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required]
    public string? _CustomerName;
    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required]
    public string? _CustomerPhone;
    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required]
    public string? _CustomerEmail;
    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required]
    public string? _CustomerPriority;
    [ObservableProperty]
    public string? _CustomerAddress;
    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required]
    public string? _CustomerCity;
    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required]
    public string? _CustomerState;
    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required]
    public string? _CustomerZip;
    #endregion

    IUnitOfWork UnitOfWork { get; set; }

    public ICommand UpdateCustomerCommand { get; }
    public ICommand DeleteCustomerCommand { get; }
    public CustomerViewModel(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
        Customers = new ObservableCollection<Customer>(UnitOfWork.Customers.FindAll());

        UpdateCustomerCommand = new RelayCommand(UpdateCustomer);
        DeleteCustomerCommand = new RelayCommand(DeleteCustomer);
    }

    private void DeleteCustomer()
    {
        if (SelectedCustomer != null)
        {
            // See if customer is associated with any tickets 
            var tickets = UnitOfWork.Tickets.FindBy(ticket => ticket.Customer_Id == SelectedCustomer.Id);

            if (tickets.Any())
            {
                // Ask if user is sure they want to delete customer despite ticket removals.
                var result = MessageBox.Show("Are you sure you want to remove this customer? This customer is associated with tickets and this action will remove those tickets as well.",
                    "Delete?", MessageBoxButton.YesNoCancel);

                if (result == MessageBoxResult.Yes)
                {
                    // Remove tickets and save changes
                    foreach (var ticket in tickets)
                    {
                        UnitOfWork.Tickets.Delete(ticket);
                    }
                    UnitOfWork.Commit();

                    // Delete Selected customer, save changes, and update list.
                    UnitOfWork.Customers.Delete(SelectedCustomer);
                    UnitOfWork.Commit();
                    Customers = new ObservableCollection<Customer>(UnitOfWork.Customers.FindAll());
                    ClearFields();
                }
                else
                {
                    return;
                }
            }

            if (!tickets.Any())
            {
                var result = MessageBox.Show("Are you sure you want to remove this customer?", "Delete customer?", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    // Delete Selected customer, save changes, and update list.
                    UnitOfWork.Customers.Delete(SelectedCustomer);
                    UnitOfWork.Commit();
                    Customers = new ObservableCollection<Customer>(UnitOfWork.Customers.FindAll());
                    ClearFields();
                }
            }
        }
        else
        {
            MessageBox.Show("No customer is selected to delete.");
        }
    }

    private void UpdateCustomer()
    {
        if (SelectedCustomer != null)
        {
            ValidateAllProperties();
            if (!HasErrors)
            {
                // Update Entity with Changes
                SelectedCustomer.Name = CustomerName;
                SelectedCustomer.Email = CustomerEmail;
                SelectedCustomer.Phone = CustomerPhone;
                SelectedCustomer.Is_Priority = CustomerPriority == "High" ? 1 : 0;
                SelectedCustomer.Address = CustomerAddress;
                SelectedCustomer.City = CustomerCity;
                SelectedCustomer.State = CustomerState;
                SelectedCustomer.Zip = CustomerZip;

                // Update Customer, Commit, and Refresh Customers
                UnitOfWork.Customers.Update(SelectedCustomer);
                UnitOfWork.Commit();
                Customers = new ObservableCollection<Customer>(UnitOfWork.Customers.FindAll());
            }
            else
            {
                MessageBox.Show("Highlighted fields are required.");
            }
        }
        else
        {
            MessageBox.Show("No customer is selected to edit.");
        }
    }

    partial void OnSelectedCustomerChanged(Customer value)
    {
        if (value != null)
        {
            // Update Customer Fields From Entity
            CustomerName = value.Name;
            CustomerEmail = value.Email;
            CustomerPhone = value.Phone;
            CustomerPriority = value.Is_Priority == 1 ? "High" : "Standard";
            CustomerAddress = value.Address;
            CustomerCity = value.City;
            CustomerState = value.State;
            CustomerZip = value.Zip;
        }
    }

    public void ClearFields()
    {
        CustomerName = "";
        CustomerEmail = "";
        CustomerPhone = "";
        CustomerPriority = "";
        CustomerAddress = "";
        CustomerState = "";
        CustomerCity = "";
        CustomerZip = "";
    }
}
