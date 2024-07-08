using CommunityToolkit.Mvvm.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using TicketManagementSystem_Capstone.Data;
using TicketManagementSystem_Capstone.Repository;
using TicketManagementSystem_Capstone.Repository.Interfaces;
using TicketManagementSystem_Capstone.Services;
using TicketManagementSystem_Capstone.View;
using TicketManagementSystem_Capstone.ViewModel;
using TicketManagementSystem_Capstone.ViewModel.Administration;

namespace TicketManagementSystem_Capstone;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IHost _host;

    [STAThread]
    public static void Main(string[] args)
    {
        // Create and start host
        _host = CreateHostBuilder(args).Build();
        _host.Start();

        // Run app with login window
        App app = new();
        app.InitializeComponent();

        
        app.MainWindow = _host.Services.GetRequiredService<MainView>();
        app.MainWindow.Visibility = Visibility.Visible;
        app.Run();
        
    }

    // Creates host builder and adds services via DI
    private static IHostBuilder CreateHostBuilder(string[]? args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<MainView>();
                services.AddSingleton<MainViewModel>();
                services.AddTransient<LoginView>();
                services.AddTransient<LoginViewModel>();
                services.AddTransient<TicketControlViewModel>();
                services.AddTransient<TicketControlView>();
                services.AddTransient<CreateNewTicketView>();
                services.AddTransient<CreateNewTicketViewModel>();
                services.AddTransient<ArchiveTicketView>();
                services.AddTransient<ArchiveTicketViewModel>();
                services.AddTransient<CustomerView>();
                services.AddTransient<CustomerViewModel>();
                services.AddTransient<TicketTabControlView>();
                services.AddTransient<TicketTabControlViewModel>();
                services.AddTransient<CustomerTabControlView>();
                services.AddTransient<CustomerTabControlViewModel>();
                services.AddTransient<CreateNewCustomerView>();
                services.AddTransient<CreateNewCustomerViewModel>();
                services.AddTransient<ReportsTabControlView>();
                services.AddTransient<ReportsTabControlViewModel>();
                services.AddTransient<AdministrationTabControlView>();
                services.AddTransient<AdministrationTabControlViewModel>();
                services.AddTransient<EmployeeView>();
                services.AddTransient<EmployeeViewModel>();
                services.AddTransient<CreateEmployeeView>();
                services.AddTransient<CreateEmployeeViewModel>();
                services.AddSingleton<VVMService>();
                services.AddDbContext<DuraTechDbContext>(options =>
                {
                    options.UseSqlServer(
                        "Server=TRANCE\\MSSQLSERVERNAMED;Database=DuraTechDB;Trusted_Connection=True;TrustServerCertificate=True");
                });

                // Adding repositories
                services.AddSingleton<IMessenger, WeakReferenceMessenger>();
                services.AddScoped<IUserRepository, UserRepository>();
                services.AddScoped<ITicketRepository, TicketRepository>();
                services.AddScoped<ICustomerRepository, CustomerRepository>();
                services.AddScoped<IUnitOfWork, UnitOfWork>();
            });
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
    }
}
