using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.Hosting;
using TicketManagementSystem_Capstone.View;

namespace TicketManagementSystem_Capstone
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        [STAThread]
        public static void Main(string[]? args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            host.Start();
            App app = new();
            app.InitializeComponent();
            app.Run();
        }

        private static IHostBuilder CreateHostBuilder(string[]? args)
        {
           return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {

                });
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }
    }

}
