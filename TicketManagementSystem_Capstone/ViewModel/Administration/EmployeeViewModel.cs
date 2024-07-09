using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using TicketManagementSystem_Capstone.Models;
using TicketManagementSystem_Capstone.Repository.Interfaces;

namespace TicketManagementSystem_Capstone.ViewModel.Administration;

public partial class EmployeeViewModel : BaseViewModel, IBaseTabViewModel
{
    public string TabName { get; set; } = "Employees";

    [ObservableProperty]
    public List<string> _Teams = new List<string> {"", "Tech Support", "Maintenance Team" };

    [ObservableProperty]
    public ObservableCollection<User>? _Users;

    [ObservableProperty]
    public User? _SelectedUser;
    private string _filterString;

    #region User Fields
    [ObservableProperty]
    public string? _Email;
    [ObservableProperty]
    public string? _Password;
    [ObservableProperty]
    public string? _FirstName;
    [ObservableProperty]
    public string? _LastName;
    [ObservableProperty]
    public string? _Team;
    #endregion

    public IUnitOfWork UnitOfWork { get; set; }

    public ICommand FilterUsersCommand { get; }
    public ICommand UpdateUserCommand { get; }
    public ICommand DeleteUserCommand { get; }

    public EmployeeViewModel(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;

        Users = new ObservableCollection<User>(UnitOfWork.Users.FindAll());

        FilterUsersCommand = new RelayCommand<string>(FilterUsers);
        UpdateUserCommand = new RelayCommand(UpdateUser);
        DeleteUserCommand = new RelayCommand(DeleteUser);
    }

    // Deletes the selected user after verification from user.
    private void DeleteUser()
    {
        if (SelectedUser != null)
        {
            var result = MessageBox.Show("Are you sure you want to delete the selected user? This action can not be undone.", "Delete User?", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                UnitOfWork.Users.Delete(SelectedUser);
                UnitOfWork.Commit();
            }
        }
    }

    // Updates the selected user and refreshes list
    private void UpdateUser()
    {
        if (SelectedUser != null)
        {
            if (ChangesMade())
            {
                // Copy changed information
                SelectedUser.First_Name = FirstName;
                SelectedUser.Last_Name = LastName;
                SelectedUser.Email = Email;
                SelectedUser.Team = Team;

                UnitOfWork.Users.Update(SelectedUser);
                UnitOfWork.Commit();

                FilterUsers(_filterString);
            }
        }
    }


    // Used to filter users based on radio button selection
    private void FilterUsers(string? filterString)
    {
        switch (filterString)
        {
            case "All":
                Users = new ObservableCollection<User>(UnitOfWork.Users.FindAll());
                break;
            case "Tech":
                Users = new ObservableCollection<User>(UnitOfWork.Users.GetTechnicalSupportUsers());
                break;
            case "Maintenance":
                Users = new ObservableCollection<User>(UnitOfWork.Users.GetMaintenanceUsers());
                break;
        }

        Clear();
        _filterString = filterString;
    }
    public void Clear()
    {
        SelectedUser = null;
        FirstName = "";
        LastName = "";
        Email = "";
        Team = "";
        Password = "";
    }
    partial void OnSelectedUserChanged(User? value)
    {
        if (value != null)
        {
            FirstName = SelectedUser.First_Name;
            LastName = SelectedUser.Last_Name;
            Email = SelectedUser.Email;
            Password = SelectedUser.Password;
            Team = SelectedUser.Team;
        }
    }

    private bool ChangesMade()
    {
        if(SelectedUser.Team != Team ||
            SelectedUser.First_Name != FirstName ||
            SelectedUser.Last_Name != LastName ||
            SelectedUser.Email != Email ||
            SelectedUser.Password != Password)
        {
            return true;
        }
        return false;
    }
}
