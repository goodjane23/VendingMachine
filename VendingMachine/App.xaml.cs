using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using VendingMachine.ViewModels;
using VendingMachine.Views.Windows;

namespace VendingMachine;

public partial class App : Application
{
    private readonly ServiceProvider serviceProvider;
    
    public App()
    {
        var services = new ServiceCollection();
        
        // Windows
        services.AddSingleton<MainWindow>();
        
        //ViewModels
        services.AddSingleton<MainWindowViewModel>();

        serviceProvider = services.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var window = serviceProvider.GetRequiredService<MainWindow>();
        window.Show();
    }
}
