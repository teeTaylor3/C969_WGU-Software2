
namespace C969
{
	partial class logIn
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.userNameLabel = new System.Windows.Forms.Label();
			this.passwordLabel = new System.Windows.Forms.Label();
			this.logInBtn = new System.Windows.Forms.Button();
			this.logInLabel = new System.Windows.Forms.Label();
			this.exitBtn = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.locationLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(25, 60);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(250, 20);
			this.textBox1.TabIndex = 0;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(25, 110);
			this.textBox2.Name = "textBox2";
			this.textBox2.PasswordChar = '*';
			this.textBox2.Size = new System.Drawing.Size(250, 20);
			this.textBox2.TabIndex = 1;
			this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
			// 
			// userNameLabel
			// 
			this.userNameLabel.AutoSize = true;
			this.userNameLabel.Location = new System.Drawing.Point(25, 85);
			this.userNameLabel.Name = "userNameLabel";
			this.userNameLabel.Size = new System.Drawing.Size(60, 13);
			this.userNameLabel.TabIndex = 2;
			this.userNameLabel.Text = "User Name";
			// 
			// passwordLabel
			// 
			this.passwordLabel.AutoSize = true;
			this.passwordLabel.Location = new System.Drawing.Point(25, 135);
			this.passwordLabel.Name = "passwordLabel";
			this.passwordLabel.Size = new System.Drawing.Size(53, 13);
			this.passwordLabel.TabIndex = 3;
			this.passwordLabel.Text = "Password";
			// 
			// logInBtn
			// 
			this.logInBtn.Location = new System.Drawing.Point(90, 160);
			this.logInBtn.Name = "logInBtn";
			this.logInBtn.Size = new System.Drawing.Size(50, 25);
			this.logInBtn.TabIndex = 4;
			this.logInBtn.Text = "Log-In";
			this.logInBtn.UseVisualStyleBackColor = true;
			this.logInBtn.Click += new System.EventHandler(this.LogInBtn_Click);
			// 
			// logInLabel
			// 
			this.logInLabel.AutoSize = true;
			this.logInLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.logInLabel.Location = new System.Drawing.Point(25, 20);
			this.logInLabel.Name = "logInLabel";
			this.logInLabel.Size = new System.Drawing.Size(55, 20);
			this.logInLabel.TabIndex = 5;
			this.logInLabel.Text = "Log-In";
			// 
			// exitBtn
			// 
			this.exitBtn.Location = new System.Drawing.Point(150, 160);
			this.exitBtn.Name = "exitBtn";
			this.exitBtn.Size = new System.Drawing.Size(50, 25);
			this.exitBtn.TabIndex = 6;
			this.exitBtn.Text = "Exit";
			this.exitBtn.UseVisualStyleBackColor = true;
			this.exitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 210);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "User Location:";
			// 
			// locationLabel
			// 
			this.locationLabel.AutoSize = true;
			this.locationLabel.Location = new System.Drawing.Point(85, 210);
			this.locationLabel.Name = "locationLabel";
			this.locationLabel.Size = new System.Drawing.Size(53, 13);
			this.locationLabel.TabIndex = 8;
			this.locationLabel.Text = "Unknown";
			// 
			// logIn
			// 
			this.AcceptButton = this.logInBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(304, 236);
			this.Controls.Add(this.locationLabel);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.exitBtn);
			this.Controls.Add(this.logInLabel);
			this.Controls.Add(this.logInBtn);
			this.Controls.Add(this.passwordLabel);
			this.Controls.Add(this.userNameLabel);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Name = "logIn";
			this.Text = "Appointment Management System";
			this.Load += new System.EventHandler(this.LogIn_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label userNameLabel;
		private System.Windows.Forms.Label passwordLabel;
		private System.Windows.Forms.Button logInBtn;
		private System.Windows.Forms.Label logInLabel;
		private System.Windows.Forms.Button exitBtn;
		public System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label locationLabel;
	}
}

