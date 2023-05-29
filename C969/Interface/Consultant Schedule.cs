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
	public partial class Consultant_Schedule : Form
	{
		public Consultant_Schedule()
		{
			InitializeComponent();
		}

		private void Consultant_Schedule_Load(object sender, EventArgs e)
		{
			dgvReports.ReadOnly = true;
			try
			{
				using (MySqlConnection conn = new MySqlConnection(Helper_Functions.HelpFunctions.constr))
				{
					conn.Open();
					string queryUser = $"SELECT * FROM user";
					var userCommand = new MySqlCommand(queryUser, conn);
					MySqlDataAdapter adp = new MySqlDataAdapter(userCommand);
					DataTable user = new DataTable();
					adp.Fill(user);
					comboBox1.ValueMember = "userId";
					comboBox1.DisplayMember = "userName";
					comboBox1.DataSource = user;
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
			string username = comboBox1.Text;
			label3.Text = "Appointments for User: " + username;
			dgvReports.DataSource = null;
			try
			{
				using (MySqlConnection conn = new MySqlConnection(Helper_Functions.HelpFunctions.constr))
				{
					conn.Open();
					string queryUserId = $"SELECT userId FROM user WHERE userName = '{username}'";
					var idCommand = new MySqlCommand(queryUserId, conn);
					int userId = Convert.ToInt32(idCommand.ExecuteScalar());

					string queryAppointment = $"SELECT appointmentId, start, end FROM appointment WHERE userId = '{userId}'";
					var appointmentCommand = new MySqlCommand(queryAppointment, conn);
					MySqlDataAdapter adp = new MySqlDataAdapter(appointmentCommand);
					DataTable user = new DataTable();
					adp.Fill(user);

					dgvReports.DataSource = user;

					dgvReports.RowHeadersVisible = false;
					dgvReports.ColumnHeadersVisible = true;
					dgvReports.Columns[0].HeaderText = "Appointment ID";
					dgvReports.Columns[1].HeaderText = "Start";
					dgvReports.Columns[2].HeaderText = "End";
					dgvReports.Columns[1].DefaultCellStyle.Format = "MM-dd-yyyy hh:mm tt";
					dgvReports.Columns[2].DefaultCellStyle.Format = "MM-dd-yyyy hh:mm tt";

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
