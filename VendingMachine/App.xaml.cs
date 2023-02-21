using System.IO;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VendingMachine.Data;
using VendingMachine.Extensions;
using VendingMachine.Services.Vending;
using VendingMachine.ViewModels;
using VendingMachine.Views.Windows;

namespace VendingMachine;

public partial class App : Application
{
    private readonly IHost appHost;
    
    public App()
    {
        appHost = Host.CreateDefaultBuilder()
            .ConfigureServices(ConfigureServices)
            .Build();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<MainWindow>();
        
        services.AddWindowFactory<ProductPreviewWindow>();
        
        services.AddSingleton<MainWindowViewModel>();

        services.AddSingleton<IVendingService, VendingService>();
        
        services.AddDbContextFactory<VendingDbContext>(options =>
        {
            Directory.CreateDirectory("Data");
            options.UseSqlite("Data Source=Data\\storage.db;");
        });
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await appHost.StartAsync();

        var factory = appHost.Services.GetRequiredService<IDbContextFactory<VendingDbContext>>();

        await using (var ctx = await factory.CreateDbContextAsync())
        {
            await ctx.Database.MigrateAsync();
        }

        var window = appHost.Services.GetRequiredService<MainWindow>();
        window.Show();

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await appHost.StopAsync();
        base.OnExit(e);
    }
}
