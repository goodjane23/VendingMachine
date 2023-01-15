using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using VendingMachine.Data.Entities;

namespace VendingMachine.Data;

public class VendingDbContext : DbContext 
{
	public DbSet<Product> Products { get; set; }

	public VendingDbContext(DbContextOptions<VendingDbContext> options) 
		: base(options)
	{
		Database.EnsureCreated();	
	}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		modelBuilder.Entity<Product>()
            .HasData(GetInitialProducts());
    }

    private List<Product> GetInitialProducts()
    {
        var products = new List<Product>()
        {
            new Product()
            {
                Id = 6,
                Name = "Potion Health",
                ProductType = ProductType.Health,
                Price = 150,
                Amount = 10,
            },
            new Product()
            {
                Id = 1,
                Name = "Potion Strength",
                ProductType = ProductType.Strength,
                Price = 200,
                Amount = 10,
            },
            new Product()
            {
                Id = 2,
                Name = "Potion Agility",
                ProductType = ProductType.Agility,
                Price = 100,
                Amount = 10,
            },
            new Product()
            {
                Id = 3,
                Name = "Potion Intelligence",
                ProductType = ProductType.Intelligence,
                Price = 150,
                Amount = 10,
            },
            new Product()
            {
                Id = 4,
                Name = "Potion Invisibility",
                ProductType = ProductType.Invisibility,
                Price = 300,
                Amount = 10,
            },
            new Product()
            {
                Id = 5,
                Name = "Potion Invulnerability",
                ProductType = ProductType.Invulnerability,
                Price = 200,
                Amount = 10,
            },
            new Product()
            {
                Id = 10,
                Name = "Potion Random",
                ProductType = ProductType.Random,
                Price = 500,
                Amount = 10,
            },
            new Product()
            {
                Id = 7,
                Name = "Potion PotionType1",
                ProductType = ProductType.PotionType1,
                Price = 150,
                Amount = 10,
            },
            new Product()
            {
                Id = 8,
                Name = "Potion PotionType2",
                ProductType = ProductType.PotionType2,
                Price = 200,
                Amount = 10,
            },
            new Product()
            {
                Id = 9,
                Name = "Potion PotionType3",
                ProductType = ProductType.PotionType3,
                Price = 300,
                Amount = 10,
            },

        };
        return products;
    }

}
