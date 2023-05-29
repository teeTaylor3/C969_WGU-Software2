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
using System.Globalization;
using System.IO;
using System.Device.Location;
using C969.Helper_Functions;

namespace C969
{
	public partial class logIn : Form
	{
		private string loginError = "Username and/or Password is invalid.";
		private string successfulConnection = "Login successful for ";
		private string upcomingApp = "You have an appointment within the next 15 mins.";
		private string noUpcomingApp = "You have no appointment within the next 15 mins.";
		private string path = @"login.txt";
		public static string sendtext = "";
		private delegate string Welcome(string name);

		private bool allowLogIn()
		{
			return (!string.IsNullOrEmpty(textBox1.Text) || !string.IsNullOrEmpty(textBox2.Text));
		}

		public logIn()
		{
			InitializeComponent();
		}

		private void LogIn_Load(object sender, EventArgs e)
		{
			currentLanguage();
			locationLabel.Text = RegionInfo.CurrentRegion.EnglishName;
		}

		private void currentLanguage()
		{
			// This section of code translates the login form to french based on region.	
			switch (RegionInfo.CurrentRegion.TwoLetterISORegionName)
			{
				case "FR":
					logInLabel.Text = "Connexion";
					userNameLabel.Text = "Nom d’utilisateur";
					passwordLabel.Text = "Mot de passe";
					logInBtn.Text = "Connexion";
					exitBtn.Text = "Sortie";
					loginError = "Le Nom d’utilisateur et le Mot de passe ne correspondaient pas.";
					successfulConnection = "Connexion réussie pour ";
					upcomingApp = "Vous avez un rendez-vous dans les 15 prochaines minutes.";
					noUpcomingApp = "Vous n’avez pas de rendez-vous dans les 15 prochaines minutes.";
					break;

				default:
					logInLabel.Text = "Log-In";
					userNameLabel.Text = "User Name";
					passwordLabel.Text = "Password";
					logInBtn.Text = "Log-In";
					exitBtn.Text = "Exit";
					break;
			}

			// This section of code translates the login form to french based on culture.
			if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "FR")
			{
				logInLabel.Text = "Connexion";
				userNameLabel.Text = "Nom d’utilisateur";
				passwordLabel.Text = "Mot de passe";
				logInBtn.Text = "Connexion";
				exitBtn.Text = "Sortie";
				loginError = "Le Nom d’utilisateur et le Mot de passe ne correspondaient pas.";
				successfulConnection = "Connexion réussie pour ";
				upcomingApp = "Vous avez un rendez-vous dans les 15 prochaines minutes.";
				noUpcomingApp = "Vous n’avez pas de rendez-vous dans les 15 prochaines minutes.";
			}
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox1.Text))
			{
				logInBtn.Enabled = false;
			}
			else
			{
				logInBtn.Enabled = allowLogIn();
			}
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox2.Text))
			{
				logInBtn.Enabled = false;
			}
			else
			{
				logInBtn.Enabled = allowLogIn();
			}
		}

		// This code checks for appointments occuring within the next 15 mins.
		private bool hasUpcomingAppointment()
		{
			bool result = false;
			string username = textBox1.Text;
			try
			{
				using (MySqlConnection conn = new MySqlConnection(Helper_Functions.HelpFunctions.constr))
				{
					conn.Open();
					string queryUserId = $"SELECT userId FROM user WHERE userName = '{username}'";
					var idCommand = new MySqlCommand(queryUserId, conn);
					int userId = Convert.ToInt32(idCommand.ExecuteScalar());

					string queryUpcomingAppointment = $"SELECT * FROM appointment WHERE start BETWEEN now() AND now() + INTERVAL 15 MINUTE AND userId = '{userId}'";
					var upcomingCommand = new MySqlCommand(queryUpcomingAppointment, conn);
					int amountUpcoming = Convert.ToInt32(upcomingCommand.ExecuteScalar());

					if (amountUpcoming == 0)
					{
						result = false;
					}
					else
					{
						result = true;
					}
				}
			}
			catch (MySqlException ex)
			{
				MessageBox.Show("error" + ex);
			}
			return result;
		}

		private void LogInBtn_Click(object sender, EventArgs e)
		{
			try
			{
				using (MySqlConnection conn = new MySqlConnection(Helper_Functions.HelpFunctions.constr))
				{
					conn.Open();
					string _username = textBox1.Text;
					string password = textBox2.Text;

					string querry = $"SELECT * FROM user WHERE userName = '{_username}' AND password = '{password}'";
					MySqlCommand cmd = new MySqlCommand(querry, conn);
					MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
					DataTable dtable = new DataTable();
					sda.Fill(dtable);

					if (dtable.Rows.Count > 0)
					{
						logInBtn.Enabled = allowLogIn();
						sendtext = textBox1.Text;

						// This lambda is used to create a shorter function that welcomes users that are logging in.
						Welcome obj = (currentUserName) => { return successfulConnection + currentUserName + "."; };
						string Welcome = obj.Invoke(HelpFunctions.getCurrentUserName());
						MessageBox.Show(Welcome);
						mainMenu main = new mainMenu();
						try
						{
							// The following if statement records successful logins.
							if(File.Exists(path) == false)
							{
								File.Create(path).Dispose();
								using (TextWriter txt = new StreamWriter(path))
								{
									txt.WriteLine($"SUCCESSFUL LOGIN ATTEMPT FOR USER: {_username} AT {DateTime.Now}{Environment.NewLine}");
								}
							}
							else if(File.Exists(path) == true)
							{
								File.AppendAllText(path, $"SUCCESSFUL LOGIN ATTEMPT FOR USER: {_username} AT {DateTime.Now}{Environment.NewLine}");
							}
						}
						catch(IOException ex)
						{
							MessageBox.Show("error" + ex);
						}
						if(hasUpcomingAppointment() != true)
						{
							MessageBox.Show(noUpcomingApp, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
							main.Show();
							this.Hide();
						}
						else
						{
							MessageBox.Show(upcomingApp, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
							main.Show();
							this.Hide();
						}
					}
					else
					{
						conn.Close();
						logInBtn.Enabled = false;
						MessageBox.Show(loginError, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
						textBox1.Clear();
						textBox2.Clear();
						textBox1.Focus();
						try
						{
							// The following if statment logs unsuccessful login attempts.
							if (File.Exists(path) == false)
							{
								File.Create(path).Dispose();
								using (TextWriter txt = new StreamWriter(path))
								{
									txt.WriteLine($"UNSUCCESSFUL LOGIN ATTEMPT FOR USER: {_username} AT {DateTime.Now}{Environment.NewLine}");
								}
							}
							else if (File.Exists(path) == true)
							{
								File.AppendAllText(path, $"UNSUCCESSFUL LOGIN ATTEMPT FOR USER: {_username} AT {DateTime.Now}{Environment.NewLine}");
							}
						}
						catch (IOException ex)
						{
							MessageBox.Show("error" + ex);
						}
					}
				}
			}
			catch (MySqlException ex)
			{
				MessageBox.Show("error" + ex);
			}
		}

		private void ExitBtn_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}

