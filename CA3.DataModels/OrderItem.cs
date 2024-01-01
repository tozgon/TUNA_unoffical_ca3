using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA3.DataModels
{
	[Table("OrderItem")]
	public class OrderItem
	{
		[Key] public int OrderItemId { get; set; } // PK

		[Required] public int OrderId { get; set; }

		[Required] public string ProductName { get; set; }

		[Required] public int Quantity { get; set; }

		[Required]
		public double UnitPrice
		{
			get; set;
		}
	}
}
