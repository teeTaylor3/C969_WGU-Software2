using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969.Models
{
	public class Appointment : CommonInfo
	{
		public int appointmentID { get; set; }
		public int customerID { get; set; }
		public int userID { get; set; }
		public string title { get; set; }
		public string description { get; set; }
		public string location { get; set; }
		public string contact { get; set; }
		public string type { get; set; }
		public string url { get; set; }
		public DateTime apptStart { get; set; }
		public DateTime apptEnd { get; set; }
	}
}
