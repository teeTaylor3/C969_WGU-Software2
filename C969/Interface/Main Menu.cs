using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using C969.Helper_Functions;

namespace C969
{
	public partial class mainMenu : Form
	{
		private delegate string End(string name);
		private string appointmentId;
		public mainMenu()
		{
			InitializeComponent();
		}

		private void loadDGV()
		{
			dgvAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvAppointments.ReadOnly = true;
			dgvAppointments.RowHeadersVisible = false;
			dgvAppointments.ColumnHeadersVisible = true;
			string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
			MySqlConnection conn = new MySqlConnection(constr);
			conn.Open();
			string sqlString =
				$"SELECT customer.customerId, customer.customerName, appointment.appointmentId, appointment.type, appointment.start, appointment.end FROM customer " +
					$"JOIN appointment ON customer.customerId = appointment.customerId ORDER BY appointmentId";
			MySqlCommand cmd = new MySqlCommand(sqlString, conn);
			MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
			DataTable appt = new DataTable();
			adp.Fill(appt);

			for (int i = 0; i < appt.Rows.Count; i++)
			{
				DateTime a = (DateTime)appt.Rows[i]["start"];
				DateTime b = (DateTime)appt.Rows[i]["end"];
				appt.Rows[i]["start"] = a.ToLocalTime();
				appt.Rows[i]["end"] = b.ToLocalTime();
			}

			dgvAppointments.DataSource = appt;

			dgvAppointments.ClearSelection();
			dgvAppointments.Columns[0].HeaderText = "Customer ID";
			dgvAppointments.Columns[1].HeaderText = "Customer Name";
			dgvAppointments.Columns[2].HeaderText = "Appointment ID";
			dgvAppointments.Columns[3].HeaderText = "Appointment Type";
			dgvAppointments.Columns[4].HeaderText = "Start Time";
			dgvAppointments.Columns[4].DefaultCellStyle.Format = "MM-dd-yyyy hh:mm:ss tt";
			dgvAppointments.Columns[5].HeaderText = "End Time";
			dgvAppointments.Columns[5].DefaultCellStyle.Format = "MM-dd-yyyy hh:mm:ss tt";
		}

		private void Appointments_Load(object sender, EventArgs e)
		{
			radioButtonViewAll.Checked = true;
			comboBoxReports.Items.Add("Total Appointment Types");
			comboBoxReports.Items.Add("Consultant Schedule");
			comboBoxReports.Items.Add("Total Customer Appointments");
			loadDGV();
		}
		private void dgvAppointments_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			dgvAppointments.DefaultCellStyle.SelectionBackColor = Color.Yellow;
			dgvAppointments.DefaultCellStyle.SelectionForeColor = Color.Black;
		}

		// The following events populate and change the datagridview based on selected radio button.
		private void radioButtonViewAll_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
				MySqlConnection conn = new MySqlConnection(constr);
				conn.Open();

				loadDGV();
				if (dgvAppointments.Rows.Count == 0)
				{
					MessageBox.Show("There are no appointments to view.");
				}
			}
			catch (MySqlException ex)
			{
				MessageBox.Show("error" + ex);
			}
		}

		private void radioButtonMonthView_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
				MySqlConnection conn = new MySqlConnection(constr);
				conn.Open();
			
				string sqlString =
					$"SELECT customer.customerId, customer.customerName, appointment.appointmentId, appointment.type, appointment.start, appointment.end FROM customer " +
						$"JOIN appointment ON customer.customerId = appointment.customerId " +
						$"WHERE MONTH (appointment.start) = MONTH (NOW()) AND YEAR (appointment.start) = YEAR (NOW())" +
						$"ORDER BY appointmentId";
				MySqlCommand cmd = new MySqlCommand(sqlString, conn);
				MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
				DataTable appt = new DataTable();
				adp.Fill(appt);
					for (int i = 0; i < appt.Rows.Count; i++)
					{
						DateTime a = (DateTime)appt.Rows[i]["start"];
						DateTime b = (DateTime)appt.Rows[i]["end"];
						appt.Rows[i]["start"] = a.ToLocalTime();
						appt.Rows[i]["end"] = b.ToLocalTime();
					}
				dgvAppointments.DataSource = appt;
			}
			catch (MySqlException ex)
			{
				MessageBox.Show("error" + ex);
			}
		}

		private void radioButtonWeekView_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
				MySqlConnection conn = new MySqlConnection(constr);
				conn.Open();

				string sqlString =
					$"SELECT customer.customerId, customer.customerName, appointment.appointmentId, appointment.type, appointment.start, appointment.end FROM customer " +
						$"JOIN appointment ON customer.customerId = appointment.customerId " +
						$"WHERE WEEK (appointment.start) = WEEK (NOW()) AND YEAR (appointment.start) = YEAR (NOW())" +
						$"ORDER BY appointmentId";
				MySqlCommand cmd = new MySqlCommand(sqlString, conn);
				MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
				DataTable appt = new DataTable();
				adp.Fill(appt);
					for (int i = 0; i < appt.Rows.Count; i++)
					{
						DateTime a = (DateTime)appt.Rows[i]["start"];
						DateTime b = (DateTime)appt.Rows[i]["end"];
						appt.Rows[i]["start"] = a.ToLocalTime();
						appt.Rows[i]["end"] = b.ToLocalTime();
					}
				dgvAppointments.DataSource = appt;
			}
			catch (MySqlException ex)
			{
				MessageBox.Show("error" + ex);
			}
		}
		
		private void comboBoxReports_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBoxReports.Text == "Total Appointment Types")
			{
				Appointment_Reports appReports = new Appointment_Reports();
				appReports.Show();
			}
			else if (comboBoxReports.Text == "Consultant Schedule")
			{
				Consultant_Schedule consultantReports = new Consultant_Schedule();
				consultantReports.Show();
			}
			else if (comboBoxReports.Text == "Total Customer Appointments")
			{
				Customer_Appointments customerReports = new Customer_Appointments();
				customerReports.Show();
			}
		}

		private void customerBtn_Click(object sender, EventArgs e)
		{
			this.Hide();
			Customer_ customer = new Customer_();
			customer.Show();
		}

		private void addBtn_Click(object sender, EventArgs e)
		{
			this.Close();
			addAppointment addAppt = new addAppointment();
			addAppt.Show();
		}

		private void updtBtn_Click(object sender, EventArgs e)
		{
			if (dgvAppointments.SelectedRows.Count == 0)
			{
				MessageBox.Show("Row must be selected.");
			}
			else
			{
				this.Hide();
				updtAppointment updtAppt = new updtAppointment();
				updtAppt.Show();

				// The code below populates the update appointment form with appointment information
				updtAppt.textBoxName.Text = dgvAppointments.SelectedRows[0].Cells[1].Value.ToString();
				updtAppt.textBoxID.Text = dgvAppointments.SelectedRows[0].Cells[2].Value.ToString();
				updtAppt.comboBoxType.Text = dgvAppointments.SelectedRows[0].Cells[3].Value.ToString();
				updtAppt.dateTimePickerStart.Value = Convert.ToDateTime(dgvAppointments.SelectedRows[0].Cells[4].Value);
				updtAppt.dateTimePickerEnd.Value = Convert.ToDateTime(dgvAppointments.SelectedRows[0].Cells[5].Value);
			}
		}

		private void delBtn_Click(object sender, EventArgs e)
		{
			if (dgvAppointments.SelectedRows.Count == 0)
			{
				MessageBox.Show("Row must be selected.");
			}
			else
			{
				try
				{
					DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this appointment?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
					if (dialogResult == DialogResult.Yes)
					{
						appointmentId = dgvAppointments.SelectedRows[0].Cells[2].Value.ToString();
						string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
						MySqlConnection conn = new MySqlConnection(constr);
						conn.Open();

						string deleteAppointment = $"DELETE FROM appointment WHERE appointmentId = '{appointmentId}'";
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
			}
		}

		private void signOutLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			DialogResult dialog = MessageBox.Show("Are you sure you want to log out?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialog == DialogResult.Yes)
			{
				this.Hide();
				logIn login = new logIn();
				login.Show();
			}
		}

		private void exitBtn_Click(object sender, EventArgs e)
		{
			// This lambda is used to create a shorter function that lets users know they are exiting the application.
			End obj = (currentUserName) => { return currentUserName + "'s session has ended."; };
			string GoodBye = obj.Invoke(HelpFunctions.getCurrentUserName());
			MessageBox.Show(GoodBye);
			Application.Exit();
		}
	}
}
