using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VendingMachine.Data;
using VendingMachine.Data.Entities;
using VendingMachine.Services.Vending.Models;

namespace VendingMachine.Services.Vending;

public class VendingService : IVendingService
{
    private int vendingBalance;
    
    private readonly IDbContextFactory<VendingDbContext> contextFactory;

    public VendingService(IDbContextFactory<VendingDbContext> contextFactory)
	{
        this.contextFactory = contextFactory;
    }

	public async Task<Product> CreateProduct(CreateProductModel model)
	{        
        await using var dbContext = await contextFactory.CreateDbContextAsync();

        var product = new Product
        {            
            Name = model.Name,
            ProductType = model.ProductType,
            Price = model.Price,
            Amount = model.Amount,
        };

        await dbContext.Products.AddAsync(product);
        await dbContext.SaveChangesAsync();

        return product;
	}

    public async Task<BuyProductResponse> BuyProduct(int productId)
    {
        await using var dbContext = await contextFactory.CreateDbContextAsync();

        var boughtProduct = await dbContext.Products
            .FirstOrDefaultAsync(x => x.Id == productId);
      
        if (boughtProduct == null)
            throw new Exception($"Product with id {productId} not found!");
        
        if (boughtProduct.Amount == 0)
            throw new Exception($"Product with id {productId} is out of stock");
        
        if (vendingBalance < boughtProduct.Price)
            throw new Exception($"Not enough money to buy {boughtProduct.Name}!");
            
        boughtProduct.Amount--;
        vendingBalance -= boughtProduct.Price;
        
        await dbContext.SaveChangesAsync();

        var response = new BuyProductResponse
        {
            LeftVendingBalance = vendingBalance,
            ProductId = boughtProduct.Id,
            ProductName = boughtProduct.Name,
            ProductType = boughtProduct.ProductType
        };

        return response;
    }

    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        await using var dbContext = await contextFactory.CreateDbContextAsync();

        return await dbContext.Products.AsNoTracking()
            .ToListAsync();
    }

    public async Task<Product> GetProductById(int productId)
    {
        await using var dbContext = await contextFactory.CreateDbContextAsync();

        var product = await dbContext.Products.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == productId);

        if (product is null)
            throw new Exception("Product with id {productId} not found!");

        return product;
    }

    public int InsertMoney(int value)
    {
        vendingBalance += value;
        return vendingBalance;
    }
    
    public int TakeOddMoney()
    {
        var oddMoney = vendingBalance;
        vendingBalance = 0;
        
        return oddMoney;
    }
}
