﻿using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using VendingMachine.Data.Entities;
using VendingMachine.Factories;
using VendingMachine.Services.Vending;
using VendingMachine.Services.Vending.Models;
using VendingMachine.Views.Windows;

namespace VendingMachine.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private string displayText = string.Empty;
    
    [ObservableProperty]
    private int vendingBalance;

    public ObservableCollection<Product> ShowcaseItems { get; }

    public ICommand OkCommand { get; }
    public ICommand CancelCommand { get; }
    public ICommand TakeOddMoneyCommand { get; }
    public ICommand PushCommand { get; }
    public IRelayCommand<string> InsertMoneyCommand { get; }

    private int boughtProductId;
    
    private readonly IVendingService vendingService;
    private readonly WindowFactory<ProductPreviewWindow> previewWindowFactory;

    public MainWindowViewModel(
        IVendingService vendingService,
        WindowFactory<ProductPreviewWindow> previewWindowFactory)
    {
        this.vendingService = vendingService;
        this.previewWindowFactory = previewWindowFactory;

        ShowcaseItems = new ObservableCollection<Product>(vendingService.GetAllProducts().Result);

        OkCommand = new AsyncRelayCommand(BuySelectedProduct);

        PushCommand = new RelayCommand(TakeBoughtProduct);
        TakeOddMoneyCommand = new RelayCommand(TakeOddMoney);
        CancelCommand = new RelayCommand(() => DisplayText = "");
        InsertMoneyCommand = new RelayCommand<string>(InsertMoney);
    }

    private async Task BuySelectedProduct()
    {
        BuyProductResponse? productResponse = null;
        
        try
        {
            var productId = int.Parse(DisplayText);
            productResponse = await vendingService.BuyProduct(productId);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка!");
        }

        VendingBalance = productResponse?.LeftVendingBalance ?? 0;
        boughtProductId = productResponse?.ProductId ?? 0;
    }

    private void TakeBoughtProduct()
    {
        var window = previewWindowFactory.Create();
        window.ShowProduct(boughtProductId);
    }

    private void InsertMoney(string? value)
    {
        var moneyValue = int.Parse(value ?? "0");
        VendingBalance = vendingService.InsertMoney(moneyValue);
    }

    private void TakeOddMoney()
    {
        var oddMoney = vendingService.TakeOddMoney();
            
        MessageBox.Show($"Ваша сдача {oddMoney} р. Спасибо за покупку!", "Ваша сдача");
        VendingBalance = 0;
    }
}
