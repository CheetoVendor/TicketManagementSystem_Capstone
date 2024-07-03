using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TicketManagementSystem_Capstone.Models;
using TicketManagementSystem_Capstone.Repository.Interfaces;

namespace TicketManagementSystem_Capstone.ViewModel;

public partial class CreateNewCustomerViewModel : BaseViewModel, IBaseTabViewModel
{
    public string TabName { get; set; } = "Add Customer";

    [ObservableProperty]
    public List<string> _Priorities = new List<string> { "", "High", "Standard" };

    [ObservableProperty]
    public string? _CustomerName;
    [ObservableProperty]
    public string? _Phone;
    [ObservableProperty]
    public string? _Email;
    [ObservableProperty]
    public string? _Priority;
    [ObservableProperty]
    public string? _Address;
    [ObservableProperty]
    public string? _City;
    [ObservableProperty]
    public string? _State;
    [ObservableProperty]
    public string? _Zip;

    // Error Handling 
    public bool? HasErrors => Errors.Any();
    private Dictionary<string, List<string>> Errors = new();
    

    public ICommand CreateCustomerCommand { get; }
    public ICommand ClearCommand { get; }
    public IUnitOfWork UnitOfWork { get; }

    public CreateNewCustomerViewModel(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
        CreateCustomerCommand = new RelayCommand(AddCustomer, CanAddCustomer);
        ClearCommand = new RelayCommand(Clear);
    }

    private void Clear()
    {
        CustomerName = "";
        Phone = "";
        Email = "";
        Priority = "";
        Address = "";
        City = "";
        State = "";
        Zip = "";
    }

    private void AddCustomer()
    {
        UnitOfWork.Customers.Add(new Customer
        {
            Name = CustomerName,
            Phone = Phone,
            Email = Email,
            Is_Priority = Priority == "High" ? 1 : 0,
            Address = Address,
            City = City,
            State = State,
            Zip = Zip
        });
    }

    private bool CanAddCustomer()
    {
        return !HasErrors;
    }
}
