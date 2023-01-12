using Microsoft.EntityFrameworkCore;
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

}
