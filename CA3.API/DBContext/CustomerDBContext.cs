using System.Collections.Generic;
using CA3.DataModels;
using Microsoft.EntityFrameworkCore;

namespace CA3.API.DBContext
{
	public class CustomerDbContext : DbContext
	{
		public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
			: base(options)
		{
		}

		public DbSet<Customer> Customers { get; set; } = null!;

		public DbSet<Order> Orders { get; set; } = null!;

		public DbSet<OrderItem> OrderItems { get; set; } = null!;
	}
}
