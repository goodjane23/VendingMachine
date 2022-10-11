using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VendingMachine.Data;
using VendingMachine.ViewModels;
using VendingMachine.Views.Windows;

namespace VendingMachine;

public partial class App : Application
{
  
    private readonly IHost appHost;
    
    public App()
    {
        var services = new ServiceCollection();

        appHost = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                // Windows
                services.AddSingleton<MainWindow>();

                //ViewModels
                services.AddSingleton<MainWindowViewModel>();
                services.AddDbContextFactory<VendingDbContext>(options =>
                {
                    options.UseSqlite("Data Source=Data\\storage.db;");
                });
            })
            .Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await appHost.StartAsync();

        var window = appHost.Services.GetRequiredService<MainWindow>();
        window.Show();

        base.OnStartup(e);
    }
}
