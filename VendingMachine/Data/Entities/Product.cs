namespace VendingMachine.Data.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string SourceImage { get; set; }
    public double Price { get; set; }
    public byte Amount { get; set; }
}
