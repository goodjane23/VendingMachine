using System;
using System.Windows;
using System.Windows.Media;
using VendingMachine.Extensions;
using VendingMachine.Services.Vending;

namespace VendingMachine.Views.Windows;

public partial class ProductPreviewWindow : Window
{
    private static ImageSourceConverter imageSourceConverter = new();
    
    private int productId;
    
    private readonly IVendingService vendingService;

    public ProductPreviewWindow(IVendingService vendingService)
    {
        this.vendingService = vendingService;
        
        InitializeComponent();
    }

    public void ShowProduct(int productId)
    {
        this.productId = productId;
        
        ShowDialog();
    }

    protected override async void OnActivated(EventArgs e)
    {
        base.OnActivated(e);

        var product = await vendingService.GetProductById(productId);
        var imageSource = imageSourceConverter.ConvertFromString(product.ProductType.ToProductIcon()) as ImageSource;
        
        productIcon.Source = imageSource;
        productName.Text = product.Name;
    }
}