using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using TicketManagementSystem_Capstone.Models;
using TicketManagementSystem_Capstone.Repository.Interfaces;

namespace TicketManagementSystem_Capstone.ViewModel;

public partial class CustomerViewModel : BaseViewModel
{
    [ObservableProperty]
    public ObservableCollection<Customer> _Customers;

    [ObservableProperty]
    public Customer _SelectedCustomer;

    [ObservableProperty]
    public List<string> _Priorities = new List<string> { "", "High", "Standard" };

    #region Customer Fields
    [ObservableProperty]
    public string? _CustomerName;
    [ObservableProperty]
    public string? _CustomerPhone;
    [ObservableProperty]
    public string? _CustomerEmail;
    [ObservableProperty]
    public string? _CustomerPriority;
    [ObservableProperty]
    public string? _CustomerAddress;
    [ObservableProperty]
    public string? _CustomerCity;
    [ObservableProperty]
    public string? _CustomerState;
    [ObservableProperty]
    public string? _CustomerZip;
    #endregion

    IUnitOfWork UnitOfWork { get; set; }

    public ICommand UpdateCustomerCommand { get; }
    public ICommand DeleteCustomerCommand { get; }
    public CustomerViewModel(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
        Customers = new ObservableCollection<Customer>(UnitOfWork.Customers.FindAll());
        SelectedCustomer = Customers.FirstOrDefault();

        UpdateCustomerCommand = new RelayCommand(UpdateCustomer);
        DeleteCustomerCommand = new RelayCommand(DeleteCustomer);
        
    }

    private void DeleteCustomer()
    {
        var result = MessageBox.Show("Are you sure you want to remove this customer?", "Delete?", MessageBoxButton.YesNoCancel);

        if(result == MessageBoxResult.Yes)
        {
            UnitOfWork.Customers.Delete(SelectedCustomer);
            UnitOfWork.Commit();
            Customers = new ObservableCollection<Customer>(UnitOfWork.Customers.FindAll());
        }
    }

    private void UpdateCustomer()
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

    partial void OnSelectedCustomerChanged(Customer value)
    {
        if(value != null)
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
}
