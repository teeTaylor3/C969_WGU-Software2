using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969.Models
{
	public class User: CommonInfo
	{
		public int userID { get; set; }
		public string username { get; set; }
		public string password { get; set; }
		public bool active { get; set; }
	}
}
