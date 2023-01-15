using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using VendingMachine.Data.Entities;
using VendingMachine.Services.Vending;
using VendingMachine.Services.Vending.Models;

namespace VendingMachine.ViewModels;

public class MainWindowViewModel : ObservableObject
{

    private readonly IVendingService vendingService;
    private string displayText = string.Empty;

    public string DisplayText
    {
        get => displayText;
        set => SetProperty(ref displayText, value);
    }

    private int vendingBalance = 0;
    public int VendingBalance
    {
        get => vendingBalance;
        set => SetProperty(ref vendingBalance, value);
    }

    public ObservableCollection<Product> ShowcaseItems { get; }

    public ICommand OkCommand { get; }
    public ICommand CancelCommand { get; }
    public ICommand TakeOddMoneyCommand { get; }
    public IRelayCommand<string> InsertMoneyCommand { get; }
    
    public MainWindowViewModel(IVendingService vendingService)
    {
        this.vendingService = vendingService;      
        
        ShowcaseItems = new ObservableCollection<Product>(vendingService
            .GetAllProducts()
            .GetAwaiter()
            .GetResult());

        OkCommand = new RelayCommand(DisplaySelectedProduct);
        TakeOddMoneyCommand = new RelayCommand(TakeOddMoney);
        CancelCommand = new RelayCommand(() => DisplayText = "");
       
        InsertMoneyCommand = new RelayCommand<string>(InsertMoney);

        CancelCommand = new RelayCommand(() => DisplayText = "");       
    }

    private void DisplaySelectedProduct()
    {
        MessageBox.Show($"Товар #{DisplayText}", "Выбран товар");
    }

    private void InsertMoney(string? value)
    {
        var moneyValue = int.Parse(value ?? "0");
        VendingBalance += moneyValue;
    }

    private void TakeOddMoney()
    {
        if (VendingBalance > 0)
        {
            MessageBox.Show($"Ваша сдача {VendingBalance} р. Спасибо за покупку!", "Ваша сдача");
            VendingBalance = 0;
        }
    }
}
