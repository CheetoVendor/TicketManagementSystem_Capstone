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
        var result = MessageBox.Show("Are you sure you want to remove this customer?", "Delete?", MessageBoxButton.YesNoCancel);

        if(result == MessageBoxResult.Yes)
        {
            UnitOfWork.Customers.Delete(SelectedCustomer);
        }
    }

    private void UpdateCustomer()
    {
        UnitOfWork.Customers.Update(SelectedCustomer);
    }
}
