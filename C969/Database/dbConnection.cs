﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace C969.Database
{
	public class dbConnection
	{
		public static MySqlConnection conn { get; set; }

		public static void startConnection() 
		{
			try
			{
				string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;

				conn = new MySqlConnection(constr);

				conn.Open();
			}
			catch (MySqlException ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		public static void closeConnection()
		{
			try
			{
				if (conn != null)
				{
					conn.Close();
				}
				conn = null;
			}
			catch (MySqlException ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
