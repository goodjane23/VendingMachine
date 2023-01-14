using Microsoft.EntityFrameworkCore;
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
}
