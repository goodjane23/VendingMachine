using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using VendingMachine.Data.Entities;

namespace VendingMachine.ViewModels;

public class MainWindowViewModel : ObservableObject
{
    private string displayText = string.Empty;
    public string DisplayText
    {
        get => displayText;
        set => SetProperty(ref displayText, value);
    }

    public ObservableCollection<Product> ShowcaseItems { get; set; }

    public ICommand OkCommand { get; }
    public ICommand CancelCommand { get; }
    
    public MainWindowViewModel()
    {
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

        ShowcaseItems = new ObservableCollection<Product>(products);

        OkCommand = new RelayCommand(() => MessageBox.Show($"Товар #{DisplayText}", "Выбран товар"));
        CancelCommand = new RelayCommand(() => DisplayText = "");
    }
}
