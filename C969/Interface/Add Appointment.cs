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
	public partial class addAppointment : Form
	{
		private delegate bool AllowSave();
		int appointmentId = Helper_Functions.HelpFunctions.newID("appointment", "appointmentId") + 1;

		public addAppointment()
		{
			InitializeComponent();
		}
		
		private void addAppointment_Load(object sender, EventArgs e)
		{
			MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["localdb"].ConnectionString);
			conn.Open();

			string queryUser = $"SELECT * FROM customer";
			var userCommand = new MySqlCommand(queryUser, conn);
			MySqlDataAdapter adp = new MySqlDataAdapter(userCommand);
			DataTable customer = new DataTable();
			adp.Fill(customer);
			comboBoxName.ValueMember = "customerId";
			comboBoxName.DisplayMember = "customerName";
			comboBoxName.DataSource = customer;
			comboBoxName.SelectedIndex = -1;

			comboBoxType.Items.Add("Scrum");
			comboBoxType.Items.Add("Presentation");

			textBoxID.Text = appointmentId.ToString();
			usernameLabel.Text = Helper_Functions.HelpFunctions.getCurrentUserName();

			dateTimePickerStart.ShowUpDown = true;
			dateTimePickerStart.Format = DateTimePickerFormat.Custom;
			dateTimePickerStart.CustomFormat = "MM-dd-yyyy hh:mm tt";
			dateTimePickerEnd.ShowUpDown = true;
			dateTimePickerEnd.Format = DateTimePickerFormat.Custom;
			dateTimePickerEnd.CustomFormat = "MM-dd-yyyy hh:mm tt";

			// The following creates a tooltip
			timeTip1.Active = true;
			timeTip1.AutoPopDelay = 5000;
			timeTip1.InitialDelay = 500;
			timeTip1.IsBalloon = true;
			timeTip1.ToolTipIcon = ToolTipIcon.Info;
			timeTip1.SetToolTip(dateTimePickerStart, "Hours of Operation: 9AM - 5PM.");
			timeTip1.SetToolTip(dateTimePickerEnd, "Hours of Operation: 9AM - 5PM.");
		}

		private void savebtn_Click(object sender, EventArgs e)
		{
				DateTime apptStart = dateTimePickerStart.Value;
				DateTime apptEnd = dateTimePickerEnd.Value;
				DateTime systenStart = apptStart.ToUniversalTime();
				DateTime systemEnd = apptEnd.ToUniversalTime();
			try
			{
				// This lambda checks every combobox on the form to validate that a value was selected for each when the user attempts to save.
				AllowSave allowSave = () =>
				{
					bool result = false;
					if (string.IsNullOrEmpty(comboBoxName.Text) || string.IsNullOrEmpty(comboBoxType.Text))
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
					MessageBox.Show("All fields are required");
				}
				else 
				{
					if ((string.IsNullOrEmpty(comboBoxName.Text)) || (string.IsNullOrEmpty(comboBoxType.Text)))
					{
						MessageBox.Show("All fields are required.");
						this.Focus();
					}
					else if (apptEnd < apptStart)
					{
						MessageBox.Show("Appointment's start time must be before the end time.");
					}
					else if ((apptStart.Hour < 9) || (apptStart.Hour > 17) || (apptEnd.Hour > 17))
					{
						MessageBox.Show("Appointment must be within hours of operation.");
					}
					else if (apptStart.Date != apptEnd.Date)
					{
						MessageBox.Show("Appointments cannot extend to multiple days.");
					}
					else
					{
						using (MySqlConnection conn = new MySqlConnection(Helper_Functions.HelpFunctions.constr))
						{
							conn.Open();
							string customerName = comboBoxName.Text;
							string type = comboBoxType.Text;
							string userName = Helper_Functions.HelpFunctions.getCurrentUserName();
							int userId = Helper_Functions.HelpFunctions.getCurrentUserID();

							string customerIdQuery = $"SELECT customerId FROM customer WHERE customerName = '{customerName}'";
							var idCommand = new MySqlCommand(customerIdQuery, conn); 
							int customerId = Convert.ToInt32(idCommand.ExecuteScalar());

							bool noOverlap()
							{
								bool result = false;
								{
									string overlap = $"SELECT * FROM appointment WHERE EXISTS" +
											$"(SELECT * FROM appointment WHERE start <= '{apptEnd.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}' " +
											$"AND end >= '{apptStart.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}' AND userId = '{userId}')";
									var overlapCommand = new MySqlCommand(overlap, conn);
									int amountOverlap = Convert.ToInt32(overlapCommand.ExecuteScalar());
									
									if (amountOverlap > 0)
									{
										result = false;
									}
									else
									{
										result = true;
									}
								}
								return result;
							}

							if (noOverlap() == false)
							{
								MessageBox.Show("Appointment at this time already exist for User: " + userName + "!");
							}
							else
							{
								string queryAppointment = $"INSERT INTO appointment(appointmentId, customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy)" +
									$"VALUES('{appointmentId}','{customerId}', '{userId}', 'not needed', 'not needed', 'not needed', 'not needed', '{type}', 'not needed', '{apptStart.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', " +
									$"'{apptEnd.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', NOW(), '{userName}', NOW(), '{userName}')";
								var appointmentCommand = new MySqlCommand(queryAppointment, conn);
								appointmentCommand.Prepare();
								appointmentCommand.ExecuteNonQuery();

								conn.Close();
								this.Close();
								mainMenu appt = new mainMenu();
								appt.Show();
							}
						}
					}
				}
			}
			catch (MySqlException ex)
			{
				MessageBox.Show("error" + ex);
			}
		}
		
		private void cancelBtn_Click(object sender, EventArgs e)
		{
			DialogResult dialog = MessageBox.Show("Are you sure you want to return to the previous screen without saving?", "",
				MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialog == DialogResult.Yes)
			{
				this.Close();
				mainMenu appt = new mainMenu();
				appt.Show();
			}
			else
			{
				this.Show();
			}
		}
    }
}
