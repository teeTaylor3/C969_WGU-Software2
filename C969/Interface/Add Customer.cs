using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace C969
{
	public partial class addCustomer : Form
	{
	
		private delegate bool AllowSave();

		public addCustomer()
		{
			InitializeComponent();
		}

		private void addCustomer_Load(object sender, EventArgs e)
		{
			MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["localdb"].ConnectionString);
			conn.Open();
			usernameLabel.Text = Helper_Functions.HelpFunctions.getCurrentUserName();
		}

		private void savebtn_Click(object sender, EventArgs e)
		{
			// This lambda checks every textbox on the form to ensure that there is input, which is useful because it reduced my validation code
			AllowSave allowSave = () =>
			{
				bool result = false;
				if ((string.IsNullOrEmpty(textBoxName.Text)) || (string.IsNullOrEmpty(textBoxPhone.Text)) ||
					(string.IsNullOrEmpty(textBoxAddress.Text)) || (string.IsNullOrEmpty(textBoxCity.Text)) ||
					(string.IsNullOrEmpty(textBoxCountry.Text)) || (string.IsNullOrEmpty(textBoxP_Code.Text)))
					{
						result = false;
					}
				else
				{
					result = true;
				}
				return result;
			};
			
			if (allowSave() != true)
			{
				savebtn.Enabled = false;
				MessageBox.Show("All fields are required");
			}
			else
			{
				using (MySqlConnection conn = new MySqlConnection(Helper_Functions.HelpFunctions.constr))
				{
					conn.Open();
					int customerId = Helper_Functions.HelpFunctions.newID("customer", "customerId") + 1;
					int addressId = Helper_Functions.HelpFunctions.newID("address", "addressId") + 1;
					int cityId = Helper_Functions.HelpFunctions.newID("city", "cityId") + 1;
					int countryId = Helper_Functions.HelpFunctions.newID("country", "countryId") + 1;
					string user = Helper_Functions.HelpFunctions.getCurrentUserName();

					string queryCountry = $"INSERT INTO country(countryId, country, createDate, createdBy, lastUpdate, lastUpdateBy)" +
						$"VALUES('{countryId}', '{textBoxCountry.Text}', NOW(), '{user}', NOW(), '{user}')";
					var countryCommand = new MySqlCommand(queryCountry, conn);
					countryCommand.Prepare();
					countryCommand.ExecuteNonQuery();

					string queryCity = $"INSERT INTO city(cityId, city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy)" +
						$"VALUES('{cityId}', '{textBoxCity.Text}', '{countryId}', NOW(), '{user}', NOW(), '{user}')";
					var cityCommand = new MySqlCommand(queryCity, conn);
					cityCommand.Prepare();
					cityCommand.ExecuteNonQuery();

					string queryAddress = $"INSERT INTO address(addressId, address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy)" +
						$"VALUES('{addressId}', '{textBoxAddress.Text}', '', '{cityId}', '{textBoxP_Code.Text}', '{textBoxPhone.Text}', NOW(), '{user}', NOW(), '{user}')";
					var addressCommand = new MySqlCommand(queryAddress, conn);
					addressCommand.Prepare();
					addressCommand.ExecuteNonQuery();

					string queryCustomer = $"INSERT INTO customer(customerId, customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy)" +
						$"VALUES('{customerId}', '{textBoxName.Text}', '{addressId}', 1, NOW(), '{user}', NOW(), '{user}')";
					var customerCommand = new MySqlCommand(queryCustomer, conn);
					customerCommand.Prepare();
					customerCommand.ExecuteNonQuery();

					conn.Close();
				}
				this.Close();
				Customer_ main = new Customer_();
				main.Show();
			}
		}

		private void cancelBtn_Click(object sender, EventArgs e)
		{
			DialogResult dialog = MessageBox.Show("Are you sure you want to return to the main screen without saving?", "", 
				MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialog == DialogResult.Yes)
			{
				this.Close();
				Customer_ main = new Customer_();
				main.Show();
			}
			else
			{
				this.Show();
			}
		}
	}
}
