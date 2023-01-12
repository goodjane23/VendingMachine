using System.Threading.Tasks;
using VendingMachine.Data.Entities;
using VendingMachine.Services.Vending.Models;

namespace VendingMachine.Services.Vending;

public interface IVendingService
{
    public Task<Product> CreateProduct(CreateProductModel model);
}
