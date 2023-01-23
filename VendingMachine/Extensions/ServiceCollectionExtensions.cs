using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using VendingMachine.Factories;

namespace VendingMachine.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddWindowFactory<TWindow>(this IServiceCollection services)
        where TWindow : Window
    {
        services.AddTransient<TWindow>();
        services.AddSingleton<Func<TWindow>>(x => () => x.GetRequiredService<TWindow>());
        services.AddSingleton<WindowFactory<TWindow>>();
    }
}