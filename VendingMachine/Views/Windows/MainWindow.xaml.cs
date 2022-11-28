using System.Collections.Generic;
using System.Windows;
using VendingMachine.Controls;
using VendingMachine.Data.Entities;
using VendingMachine.ViewModels;

namespace VendingMachine.Views.Windows;

public partial class MainWindow : Window
{
    public MainWindow(MainWindowViewModel viewModel)
    {
        InitializeComponent();

        var products = new List<Product>()
        {
            new Product { Name = "123" },
            new Product { Name = "234" },
            new Product { Name = "345" },
            new Product { Name = "123" },
            new Product { Name = "234" },
            new Product { Name = "345" },
            new Product { Name = "123" },
            new Product { Name = "234" },
            new Product { Name = "345" },
        };
        foreach (var product in products)
        {
            showcase.Items.Add(product);
        }
       
        DataContext = viewModel;
    }
}
