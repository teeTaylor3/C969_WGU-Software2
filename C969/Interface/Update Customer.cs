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
	public partial class updtCustomer : Form
	{
		public string customerName;
		private Customer_ customer_;
		private delegate bool AllowSave();

		public updtCustomer()
		{
			InitializeComponent();
		}

		public updtCustomer(Form callingform)
		{
			InitializeComponent();
			customer_ = callingform as Customer_;
			try
			{
				customerName = customer_.dgvCustomer.SelectedRows[0].Cells[1].Value.ToString();
				string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
				MySqlConnection conn = new MySqlConnection(constr);
				conn.Open();

				string customerQuery = $"SELECT * FROM customer WHERE customerName ='{customerName}'";
				var customerCommand = new MySqlCommand(customerQuery, conn);
				MySqlDataAdapter a = new MySqlDataAdapter(customerCommand);
				DataTable tempDTCustomer = new DataTable();
				a.Fill(tempDTCustomer);
				textBoxName.Text = tempDTCustomer.Rows[0][1].ToString();

				string addressQuery = $"SELECT * FROM address WHERE addressId ='{tempDTCustomer.Rows[0][2]}'";
				var addressCommand = new MySqlCommand(addressQuery, conn);
				MySqlDataAdapter ad = new MySqlDataAdapter(addressCommand);
				DataTable tempDTAddress = new DataTable();
				ad.Fill(tempDTAddress);
				textBoxAddress.Text = tempDTAddress.Rows[0][1].ToString();
				textBoxP_Code.Text = tempDTAddress.Rows[0][4].ToString();
				textBoxPhone.Text = tempDTAddress.Rows[0][5].ToString();

				string cityQuery = $"SELECT * FROM city WHERE cityId ='{tempDTAddress.Rows[0][3]}'";
				var cityCommand = new MySqlCommand(cityQuery, conn);
				MySqlDataAdapter adp = new MySqlDataAdapter(cityCommand);
				DataTable tempDTCity = new DataTable();
				adp.Fill(tempDTCity);
				textBoxCity.Text = tempDTCity.Rows[0][1].ToString();

				string countryQuery = $"SELECT * FROM country WHERE countryId ='{tempDTCity.Rows[0][2]}'";
				var countryCommand = new MySqlCommand(countryQuery, conn);
				MySqlDataAdapter adpt = new MySqlDataAdapter(countryCommand);
				DataTable tempDTCountry = new DataTable();
				adpt.Fill(tempDTCountry);
				textBoxCountry.Text = tempDTCountry.Rows[0][1].ToString();
			}
			catch(MySqlException ex)
			{
				MessageBox.Show("error" + ex);
			}
}		
		private void updCustomer_Load(object sender, EventArgs e)
		{
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
					int customerId = (int)customer_.dgvCustomer.SelectedRows[0].Cells[0].Value;
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

					string queryCustomer = $"UPDATE customer SET customerName ='{textBoxName.Text}', addressId='{addressId}', lastUpdate = NOW(), lastUpdateBy='{user}'" +
						$"WHERE customerId = '{customerId}'";
					var customerCommand = new MySqlCommand(queryCustomer, conn);
					customerCommand.Prepare();
					customerCommand.ExecuteNonQuery();

					conn.Close();
				}
				this.Close();
				Customer_ customer = new Customer_();
				customer_.dgvCustomer.Update();
				customer.Show();
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
		}
	}
}
