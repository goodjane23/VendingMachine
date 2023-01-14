using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Policy;
using System.Threading.Tasks;
using VendingMachine.Data;
using VendingMachine.Data.Entities;
using VendingMachine.Services.Vending.Models;

namespace VendingMachine.Services.Vending;

public class VendingService : IVendingService
{
    private readonly IDbContextFactory<VendingDbContext> contextFactory;

    public VendingService(IDbContextFactory<VendingDbContext> contextFactory)
	{
        this.contextFactory = contextFactory;
    }

	public async Task<Product> CreateProduct(CreateProductModel model)
	{        
        await using var dbContext = await contextFactory.CreateDbContextAsync();

        var product = new Product()
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

    public async Task BuyProduct(int productId)
    {
        await using var dbContext = await contextFactory.CreateDbContextAsync();

        var boughtProduct = await dbContext.Products.FirstOrDefaultAsync((x) => x.Id == productId);
      
        if (boughtProduct == null)
        {
            throw new Exception($"Product with id {productId} not found!");
        }
        if (boughtProduct.Amount == 0)
        {
            throw new Exception($"Product with id {productId} is out of stock");
        }
        boughtProduct.Amount--;
        await dbContext.SaveChangesAsync();
    }
}
