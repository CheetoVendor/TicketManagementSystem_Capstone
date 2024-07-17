using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using TicketManagementSystem_Capstone.Models;
using TicketManagementSystem_Capstone.Repository.Interfaces;

namespace TicketManagementSystem_Capstone.ViewModel.Reports;

public partial class TicketCompletionTimeViewModel : BaseViewModel
{
    // A report that generates the time taken to resolve tickets. 

    private IUnitOfWork UnitOfWork;

    [ObservableProperty]
    public ObservableCollection<TicketCompletion> _Items;
    [ObservableProperty]
    public DateTime? _TimeStamp;

    public TicketCompletionTimeViewModel(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;

        Items = new ObservableCollection<TicketCompletion>(UnitOfWork.Tickets.GetTicketCompletionTimes());

        TimeStamp = DateTime.Now;
    }

}
