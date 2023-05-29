
namespace C969
{
	partial class mainMenu
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.delBtn = new System.Windows.Forms.Button();
			this.updtBtn = new System.Windows.Forms.Button();
			this.addBtn = new System.Windows.Forms.Button();
			this.dgvAppointments = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.signOutLbl = new System.Windows.Forms.LinkLabel();
			this.customerBtn = new System.Windows.Forms.Button();
			this.exitBtn = new System.Windows.Forms.Button();
			this.radioButtonViewAll = new System.Windows.Forms.RadioButton();
			this.radioButtonMonthView = new System.Windows.Forms.RadioButton();
			this.radioButtonWeekView = new System.Windows.Forms.RadioButton();
			this.comboBoxReports = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
			this.SuspendLayout();
			// 
			// delBtn
			// 
			this.delBtn.Location = new System.Drawing.Point(671, 251);
			this.delBtn.Name = "delBtn";
			this.delBtn.Size = new System.Drawing.Size(140, 46);
			this.delBtn.TabIndex = 9;
			this.delBtn.Text = "Delete Appointment";
			this.delBtn.UseVisualStyleBackColor = true;
			this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
			// 
			// updtBtn
			// 
			this.updtBtn.Location = new System.Drawing.Point(674, 199);
			this.updtBtn.Name = "updtBtn";
			this.updtBtn.Size = new System.Drawing.Size(137, 46);
			this.updtBtn.TabIndex = 8;
			this.updtBtn.Text = "Update Appointment";
			this.updtBtn.UseVisualStyleBackColor = true;
			this.updtBtn.Click += new System.EventHandler(this.updtBtn_Click);
			// 
			// addBtn
			// 
			this.addBtn.Location = new System.Drawing.Point(674, 147);
			this.addBtn.Name = "addBtn";
			this.addBtn.Size = new System.Drawing.Size(137, 46);
			this.addBtn.TabIndex = 7;
			this.addBtn.Text = "Add Appointment";
			this.addBtn.UseVisualStyleBackColor = true;
			this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
			// 
			// dgvAppointments
			// 
			this.dgvAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvAppointments.Location = new System.Drawing.Point(15, 74);
			this.dgvAppointments.MultiSelect = false;
			this.dgvAppointments.Name = "dgvAppointments";
			this.dgvAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvAppointments.Size = new System.Drawing.Size(640, 327);
			this.dgvAppointments.TabIndex = 6;
			this.dgvAppointments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAppointments_CellClick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(25, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(108, 20);
			this.label1.TabIndex = 5;
			this.label1.Text = "Appointments";
			// 
			// signOutLbl
			// 
			this.signOutLbl.AutoSize = true;
			this.signOutLbl.Location = new System.Drawing.Point(765, 10);
			this.signOutLbl.Name = "signOutLbl";
			this.signOutLbl.Size = new System.Drawing.Size(48, 13);
			this.signOutLbl.TabIndex = 15;
			this.signOutLbl.TabStop = true;
			this.signOutLbl.Text = "Sign Out";
			this.signOutLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.signOutLbl_LinkClicked);
			// 
			// customerBtn
			// 
			this.customerBtn.Location = new System.Drawing.Point(671, 303);
			this.customerBtn.Name = "customerBtn";
			this.customerBtn.Size = new System.Drawing.Size(140, 46);
			this.customerBtn.TabIndex = 21;
			this.customerBtn.Text = "View Customers";
			this.customerBtn.UseVisualStyleBackColor = true;
			this.customerBtn.Click += new System.EventHandler(this.customerBtn_Click);
			// 
			// exitBtn
			// 
			this.exitBtn.Location = new System.Drawing.Point(671, 355);
			this.exitBtn.Name = "exitBtn";
			this.exitBtn.Size = new System.Drawing.Size(140, 46);
			this.exitBtn.TabIndex = 23;
			this.exitBtn.Text = "Exit";
			this.exitBtn.UseVisualStyleBackColor = true;
			this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
			// 
			// radioButtonViewAll
			// 
			this.radioButtonViewAll.AutoSize = true;
			this.radioButtonViewAll.Location = new System.Drawing.Point(19, 51);
			this.radioButtonViewAll.Name = "radioButtonViewAll";
			this.radioButtonViewAll.Size = new System.Drawing.Size(129, 17);
			this.radioButtonViewAll.TabIndex = 24;
			this.radioButtonViewAll.TabStop = true;
			this.radioButtonViewAll.Text = "View All Appointments";
			this.radioButtonViewAll.UseVisualStyleBackColor = true;
			this.radioButtonViewAll.CheckedChanged += new System.EventHandler(this.radioButtonViewAll_CheckedChanged);
			// 
			// radioButtonMonthView
			// 
			this.radioButtonMonthView.AutoSize = true;
			this.radioButtonMonthView.Location = new System.Drawing.Point(237, 51);
			this.radioButtonMonthView.Name = "radioButtonMonthView";
			this.radioButtonMonthView.Size = new System.Drawing.Size(162, 17);
			this.radioButtonMonthView.TabIndex = 25;
			this.radioButtonMonthView.TabStop = true;
			this.radioButtonMonthView.Text = "View Appointments by Month";
			this.radioButtonMonthView.UseVisualStyleBackColor = true;
			this.radioButtonMonthView.CheckedChanged += new System.EventHandler(this.radioButtonMonthView_CheckedChanged);
			// 
			// radioButtonWeekView
			// 
			this.radioButtonWeekView.AutoSize = true;
			this.radioButtonWeekView.Location = new System.Drawing.Point(479, 51);
			this.radioButtonWeekView.Name = "radioButtonWeekView";
			this.radioButtonWeekView.Size = new System.Drawing.Size(161, 17);
			this.radioButtonWeekView.TabIndex = 26;
			this.radioButtonWeekView.TabStop = true;
			this.radioButtonWeekView.Text = "View Appointments by Week";
			this.radioButtonWeekView.UseVisualStyleBackColor = true;
			this.radioButtonWeekView.CheckedChanged += new System.EventHandler(this.radioButtonWeekView_CheckedChanged);
			// 
			// comboBoxReports
			// 
			this.comboBoxReports.FormattingEnabled = true;
			this.comboBoxReports.Location = new System.Drawing.Point(674, 74);
			this.comboBoxReports.Name = "comboBoxReports";
			this.comboBoxReports.Size = new System.Drawing.Size(137, 21);
			this.comboBoxReports.TabIndex = 27;
			this.comboBoxReports.Text = "Reports";
			this.comboBoxReports.SelectedIndexChanged += new System.EventHandler(this.comboBoxReports_SelectedIndexChanged);
			// 
			// mainMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(824, 466);
			this.Controls.Add(this.comboBoxReports);
			this.Controls.Add(this.radioButtonWeekView);
			this.Controls.Add(this.radioButtonMonthView);
			this.Controls.Add(this.radioButtonViewAll);
			this.Controls.Add(this.exitBtn);
			this.Controls.Add(this.customerBtn);
			this.Controls.Add(this.signOutLbl);
			this.Controls.Add(this.delBtn);
			this.Controls.Add(this.updtBtn);
			this.Controls.Add(this.addBtn);
			this.Controls.Add(this.dgvAppointments);
			this.Controls.Add(this.label1);
			this.Name = "mainMenu";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Text = "Main Menu";
			this.Load += new System.EventHandler(this.Appointments_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button delBtn;
		private System.Windows.Forms.Button updtBtn;
		private System.Windows.Forms.Button addBtn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.LinkLabel signOutLbl;
		private System.Windows.Forms.Button customerBtn;
		private System.Windows.Forms.Button exitBtn;
		public System.Windows.Forms.DataGridView dgvAppointments;
		private System.Windows.Forms.RadioButton radioButtonViewAll;
		private System.Windows.Forms.RadioButton radioButtonMonthView;
		private System.Windows.Forms.RadioButton radioButtonWeekView;
		private System.Windows.Forms.ComboBox comboBoxReports;
	}
}