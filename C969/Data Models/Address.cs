using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969.Models
{
	public class Address : CommonInfo
	{
		public int addressID { get; set; }
		public string address{ get; set; }
		public string address2{ get; set; }
		public int cityID { get; set; }
		public string postalCode { get; set; }
		public string phone { get; set; }
	}
}
