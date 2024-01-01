using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CA3.DataModels
{
	[Table("Order")]
	public class Order
	{
		[Key]
		public int? OrderId { get; set; }

		[Required]
		public int CustomerId { get; set; }

		[Required]
		public string Date { get; set; }

		public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

	}
}
