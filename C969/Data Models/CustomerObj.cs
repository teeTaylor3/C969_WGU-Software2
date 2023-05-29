using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969.Models
{
	public class CustomerObj : CommonInfo
	{
		public int customerID { get; set; }
		public string customerName { get; set; }
		public int addressID { get; set; }
		public bool active { get; set; }
	}
}
