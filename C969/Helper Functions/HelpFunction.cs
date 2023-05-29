using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C969.Models;
using MySql.Data.MySqlClient;

namespace C969.Helper_Functions
{
	class HelpFunctions
	{
		public static string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
		private static int userId;
		public static string userName;

		public static string getCurrentUserName()
		{
			userName = logIn.sendtext;
			return userName;
		}

		public static int getCurrentUserID()
		{
			MySqlConnection conn = new MySqlConnection(constr);
			conn.Open();
			string userIdQuery = $"SELECT userId FROM user WHERE userName = '{userName}'";
			var userIdCommand = new MySqlCommand(userIdQuery, conn);
			int userId = Convert.ToInt32(userIdCommand.ExecuteScalar());
			return userId;
		}

		public static int newID(string table, string id)
		{
			MySqlConnection conn = new MySqlConnection(constr);
			conn.Open();
			string newId = $"SELECT MAX({id}) FROM {table}";
			MySqlCommand commandNewId = new MySqlCommand(newId, conn);
			MySqlDataReader reader = commandNewId.ExecuteReader();

			if (reader.HasRows)
			{
				reader.Read();
				if (reader[0] == DBNull.Value)
				{
					return 0;
				}
				return Convert.ToInt32(reader[0]);
			}
			return 0;
		}
	}
}
