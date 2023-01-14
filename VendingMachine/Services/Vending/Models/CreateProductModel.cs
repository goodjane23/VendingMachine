using VendingMachine.Data.Entities;

namespace VendingMachine.Services.Vending.Models;

public class CreateProductModel
{
    public string Name { get; set; }
    public ProductType ProductType { get; set; }
    public double Price { get; set; }
    public byte Amount { get; set; }
}