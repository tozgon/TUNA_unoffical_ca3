using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CA3.DataModels
{
	[Table("Customer")]
	public class Customer
	{
		[Key]
		public int CustomerId { get; set; }          // PK

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		[Required]
		public string DateOfBirth { get; set; }

		[Required]
		public double AnnualSpend { get; set; }

		public ICollection<Order> Orders { get; set; } = new List<Order>();

	}
}
