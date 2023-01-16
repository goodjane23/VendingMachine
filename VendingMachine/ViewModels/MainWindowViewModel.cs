using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using VendingMachine.Data.Entities;
using VendingMachine.Services.Vending;

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
    public IRelayCommand<string> InsertMoneyCommand { get; }
    
    private readonly IVendingService vendingService;
    
    public MainWindowViewModel(IVendingService vendingService)
    {
        this.vendingService = vendingService;      
        
        ShowcaseItems = new ObservableCollection<Product>(vendingService.GetAllProducts().Result);

        OkCommand = new AsyncRelayCommand(BuySelectedProduct);
        
        TakeOddMoneyCommand = new RelayCommand(TakeOddMoney);
        CancelCommand = new RelayCommand(() => DisplayText = "");
        InsertMoneyCommand = new RelayCommand<string>(InsertMoney);
    }

    private async Task BuySelectedProduct()
    {
        var productId = int.Parse(DisplayText);
        var productResponse = await vendingService.BuyProduct(productId);

        VendingBalance = productResponse.LeftVendingBalance;
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
