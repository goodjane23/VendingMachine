namespace VendingMachine.Data.Entities;

public enum ProductType
{
    Health,
    Strength,
    Agility,
    Intelligence,
    Invisibility,
    Invulnerability,
    Random,
    PotionType1,
    PotionType2,
    PotionType3,
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ProductType ProductType { get; set; }
    public double Price { get; set; }
    public byte Amount { get; set; }
}
