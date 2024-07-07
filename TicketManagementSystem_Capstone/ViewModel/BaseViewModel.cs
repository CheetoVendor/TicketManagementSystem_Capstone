using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections;
using System.ComponentModel;
using System.Windows.Controls;

namespace TicketManagementSystem_Capstone.ViewModel;

public partial class BaseViewModel : ObservableValidator
{
    /*
    // Error Handling
    private Dictionary<string, List<string>> _errors = new();
    public bool HasErrors => _errors.Any();

    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

    public IEnumerable GetErrors(string? propertyName)
    {
        if(propertyName != null && _errors.ContainsKey(propertyName))
        {
            return _errors[propertyName];
        }
        return Enumerable.Empty<string>();
    }

    protected void ClearErrors(string? propertyName)
    {
        if(propertyName == null)
        {
            _errors.Clear();
        }
        else
        {
            _errors.Remove(propertyName);
        }

        ErrorsChanged?.Invoke(this,new DataErrorsChangedEventArgs(propertyName));
    }

    // Used to add an error and/or property to dictionary
    protected void AddError(string propertyName, string error)
    {
        // If propertyname isnt in dictionary add it.
        if (!_errors.ContainsKey(propertyName))
        {
            _errors[propertyName] = new List<string>();
        }
        // if error isnt assigned to key, add it. 
        if (!_errors[propertyName].Contains(error))
        {
            _errors[propertyName].Add(error);
        }

        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }

    protected void ValidateProperty(object? value, string propertyName, Func<object, string?> validationRule)
    {
        // Clears errors before validation
        ClearErrors(propertyName);

        string? error = validationRule.Invoke(value);
        if (!string.IsNullOrEmpty(error))
        {
            AddError(propertyName, error);
        }

        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }
    */
}
