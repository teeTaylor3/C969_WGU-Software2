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
using C969.Database;
using MySql.Data.MySqlClient;
using C969.Helper_Functions;


namespace C969
{
	public partial class Customer_ : Form
	{
		public string customerId;
		public string address;
		public Customer_ Customer;
		private delegate string End(string name);

		public Customer_()
		{
			InitializeComponent();
		}

		private void loadDGV()
		{
			dgvCustomer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvCustomer.ReadOnly = true;
			dgvCustomer.RowHeadersVisible = false;

			string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
			MySqlConnection conn = new MySqlConnection(constr);
			conn.Open();

			string sqlString =
				"SELECT customer.customerId, customer.customerName, address.phone, address.address, city.city, address.postalCode, country.country FROM customer " +
					"JOIN address ON customer.addressID = address.addressID " +
					"JOIN city ON address.cityId = city.cityId " +
					"JOIN country ON city.countryId = country.countryId";
			MySqlCommand cmd = new MySqlCommand(sqlString, conn);
			MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
			DataTable cust = new DataTable();
			adp.Fill(cust);
			dgvCustomer.DataSource = cust;

			dgvCustomer.ClearSelection();
			dgvCustomer.ColumnHeadersVisible = true;
			dgvCustomer.Columns[0].HeaderText = "Customer ID";
			dgvCustomer.Columns[1].HeaderText = "Customer Name";
			dgvCustomer.Columns[2].HeaderText = "Phone Number";
			dgvCustomer.Columns[3].HeaderText = "Address";
			dgvCustomer.Columns[4].HeaderText = "City";
			dgvCustomer.Columns[5].HeaderText = "Postal Code";
			dgvCustomer.Columns[6].HeaderText = "Country";
		}

		private void Customer__Load(object sender, EventArgs e)
		{
			loadDGV();
		}

		private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			dgvCustomer.DefaultCellStyle.SelectionBackColor = Color.Yellow;
			dgvCustomer.DefaultCellStyle.SelectionForeColor = Color.Black;
		}

		private void addBtn_Click(object sender, EventArgs e)
		{
			this.Hide();
			addCustomer addCust = new addCustomer();
			addCust.Show();
		}

		private void updtBtn_Click(object sender, EventArgs e)
		{
			if (dgvCustomer.SelectedRows.Count == 0)
			{
				MessageBox.Show("Row must be selected.");
			}
			else
			{
				updtCustomer updtCust = new updtCustomer(this);
				updtCust.Show();
				this.Hide();
			}
		}

		private void delBtn_Click(object sender, EventArgs e)
		{
			if (dgvCustomer.SelectedRows.Count == 0)
			{
				MessageBox.Show("Row must be selected.");
			}
			else
			{
				try
				{
					DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this user?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
					if (dialogResult == DialogResult.Yes)
					{
						customerId = dgvCustomer.SelectedRows[0].Cells[0].Value.ToString();
						address = dgvCustomer.SelectedRows[0].Cells[3].Value.ToString();
						string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
						MySqlConnection conn = new MySqlConnection(constr);
						conn.Open();
						
						string deleteCustomer = $"DELETE FROM customer WHERE customerId = '{customerId}'";
						var customerCommand = new MySqlCommand(deleteCustomer, conn);
						customerCommand.Prepare();
						customerCommand.ExecuteNonQuery();

						string deleteAddress = $"DELETE FROM address WHERE address = '{address}'";
						var addressCommand = new MySqlCommand(deleteAddress, conn);
						addressCommand.Prepare();
						addressCommand.ExecuteNonQuery();

						string deleteAppointment = $"DELETE FROM appointment WHERE customerId = '{customerId}'";
						var appointmentCommand = new MySqlCommand(deleteAppointment, conn);
						appointmentCommand.Prepare();
						appointmentCommand.ExecuteNonQuery();
					}
					loadDGV();
				}
				catch (MySqlException ex)
				{
					MessageBox.Show("Error." + ex);
				}
				dgvCustomer.Update();
			}
		}

		private void exitBtn_Click(object sender, EventArgs e)
		{
			End obj = (currentUserName) => { return currentUserName + "'s session has ended."; };
			string GoodBye = obj.Invoke(HelpFunctions.getCurrentUserName());
			MessageBox.Show(GoodBye);
			Application.Exit();
			this.Close();
			Application.Exit();
		}

		private void signOutLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			DialogResult dialog = MessageBox.Show("Are you sure you want to log out?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialog == DialogResult.Yes)
			{
				this.Close();
				logIn login = new logIn();
				login.Show();
			}
			
		}

		private void backBtn_Click(object sender, EventArgs e)
		{
			this.Close();
			mainMenu appt = new mainMenu();
			appt.Show();
		}
	}
}
