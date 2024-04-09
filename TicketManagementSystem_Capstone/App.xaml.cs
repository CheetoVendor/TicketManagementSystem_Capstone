using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TicketManagementSystem_Capstone.View;
using TicketManagementSystem_Capstone.ViewModel;

namespace TicketManagementSystem_Capstone
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        [STAThread]
        public static void Main(string[] args)
        {
            // Create and start host
            using IHost host = CreateHostBuilder(args).Build();
            host.Start();
            // Run app with login window
            App app = new();
            app.InitializeComponent();
            app.MainWindow = host.Services.GetRequiredService<LoginView>();
            app.MainWindow.Visibility = Visibility.Visible;
            app.Run();
        }

        // Creates host builder and adds services via DI
        private static IHostBuilder CreateHostBuilder(string[]? args)
        {
           return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<LoginView>();
                    services.AddSingleton<LoginViewModel>();
                    services.AddSingleton<MainView>();
                    services.AddSingleton<MainViewModel>();
                });
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }
    }

}
