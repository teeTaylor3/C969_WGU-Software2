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
	public partial class Appointment_Reports : Form
	{
		public Appointment_Reports()
		{
			InitializeComponent();
		}

		private void Appointment_Reports_Load(object sender, EventArgs e)
		{
			dgvReports.ReadOnly = true;
			comboBox1.Items.Add("January");
			comboBox1.Items.Add("Feburary");
			comboBox1.Items.Add("March");
			comboBox1.Items.Add("April");
			comboBox1.Items.Add("May");
			comboBox1.Items.Add("June");
			comboBox1.Items.Add("July");
			comboBox1.Items.Add("August");
			comboBox1.Items.Add("September");
			comboBox1.Items.Add("October");
			comboBox1.Items.Add("November");
			comboBox1.Items.Add("December");
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			dgvReports.Rows.Clear();
			dgvReports.ClearSelection();
			dgvReports.ColumnCount = 2;
			dgvReports.Columns[0].Name = "Type";
			dgvReports.Columns[1].Name = "Amount";
			dgvReports.RowHeadersVisible = false;

			string month = comboBox1.Text;
			label3.Text = "Appointments this " + month + ":";
			int monthNum = comboBox1.SelectedIndex + 1;
			try
			{
				using (MySqlConnection conn = new MySqlConnection(Helper_Functions.HelpFunctions.constr))
				{
					conn.Open();
					string countPresentation = $"SELECT COUNT(*) FROM appointment WHERE type = 'Presentation' AND MONTH(start) = '{monthNum}'";
					var presentationCommand = new MySqlCommand(countPresentation, conn);
					int presentationAmount = Convert.ToInt32(presentationCommand.ExecuteScalar());
					dgvReports.Rows.Add("Presentation", presentationAmount);

					string countScrum = $"SELECT COUNT(*) FROM appointment WHERE type = 'Scrum' AND MONTH(start) = '{monthNum}'";
					var scrumCommand = new MySqlCommand(countScrum, conn);
					int scrumAmount = Convert.ToInt32(scrumCommand.ExecuteScalar());
					dgvReports.Rows.Add("Scrum", scrumAmount);

					dgvReports.Refresh();
				}
			}
			catch (MySqlException ex)
			{
				MessageBox.Show("error" + ex);
			}
		}

		private void backBtn_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
