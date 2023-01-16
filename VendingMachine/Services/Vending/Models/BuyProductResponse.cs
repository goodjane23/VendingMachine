using VendingMachine.Data.Entities;

namespace VendingMachine.Services.Vending.Models;

public class BuyProductResponse
{
    public int LeftVendingBalance { get; set; }
    public string ProductName { get; set; }
    public ProductType ProductType { get; set; }
}