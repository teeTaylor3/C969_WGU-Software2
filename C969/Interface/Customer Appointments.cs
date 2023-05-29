using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace C969
{
	public partial class Customer_Appointments : Form
	{
		public Customer_Appointments()
		{
			InitializeComponent();
		}

		private void Customer_Appointments_Load(object sender, EventArgs e)
		{
			try
			{
				using (MySqlConnection conn = new MySqlConnection(Helper_Functions.HelpFunctions.constr))
				{
					conn.Open();
					string queryCustomer = $"SELECT * FROM customer";
					var customerCommand = new MySqlCommand(queryCustomer, conn);
					MySqlDataAdapter adp = new MySqlDataAdapter(customerCommand);
					DataTable cust = new DataTable();
					adp.Fill(cust);
					comboBox1.ValueMember = "customerId";
					comboBox1.DisplayMember = "customerName";
					comboBox1.DataSource = cust;
				}
			}
			catch (MySqlException ex)
			{
				MessageBox.Show("error" + ex);
			}
			comboBox1.SelectedIndex = -1;
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			string customername = comboBox1.Text;
			label3.Text = "Total Appointments for Customer: " + customername;
			try
			{
				if (comboBox1.SelectedIndex == -1)
				{
					textBoxAmount.Text = null;
				}
				else
				{
					using (MySqlConnection conn = new MySqlConnection(Helper_Functions.HelpFunctions.constr))
					{
						conn.Open();
						string queryCustomerId = $"SELECT customerId FROM customer WHERE customerName = '{customername}'";
						var idCommand = new MySqlCommand(queryCustomerId, conn);
						int customerId = Convert.ToInt32(idCommand.ExecuteScalar());

						string countCustomerAppointments = $"SELECT COUNT(*) FROM appointment WHERE customerId = '{customerId}'";
						var customerAppointmentsCommand = new MySqlCommand(countCustomerAppointments, conn);
						int customerAppointmentsAmount = Convert.ToInt32(customerAppointmentsCommand.ExecuteScalar());

						textBoxAmount.Text = $"{customerAppointmentsAmount}";
					}
				}
			}
			catch (MySqlException ex)
			{
				MessageBox.Show("error" + ex);
			}
			catch (ArgumentOutOfRangeException)
			{
				MessageBox.Show("This customer has no appointments scheduled.");
			}
		}

		private void backBtn_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
