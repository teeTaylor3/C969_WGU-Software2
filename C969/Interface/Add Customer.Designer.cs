
namespace C969
{
	partial class addCustomer
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.textBoxAddress = new System.Windows.Forms.TextBox();
			this.textBoxCountry = new System.Windows.Forms.TextBox();
			this.savebtn = new System.Windows.Forms.Button();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.textBoxCity = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.usernameLabel = new System.Windows.Forms.Label();
			this.textBoxPhone = new System.Windows.Forms.MaskedTextBox();
			this.textBoxP_Code = new System.Windows.Forms.MaskedTextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(25, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(111, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Add Customer";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(25, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Name";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(25, 158);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(45, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "Address";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(25, 228);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(43, 13);
			this.label6.TabIndex = 5;
			this.label6.Text = "Country";
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(95, 85);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(100, 20);
			this.textBoxName.TabIndex = 6;
			// 
			// textBoxAddress
			// 
			this.textBoxAddress.Location = new System.Drawing.Point(95, 155);
			this.textBoxAddress.Name = "textBoxAddress";
			this.textBoxAddress.Size = new System.Drawing.Size(100, 20);
			this.textBoxAddress.TabIndex = 8;
			// 
			// textBoxCountry
			// 
			this.textBoxCountry.Location = new System.Drawing.Point(95, 225);
			this.textBoxCountry.Name = "textBoxCountry";
			this.textBoxCountry.Size = new System.Drawing.Size(100, 20);
			this.textBoxCountry.TabIndex = 10;
			// 
			// savebtn
			// 
			this.savebtn.Location = new System.Drawing.Point(95, 310);
			this.savebtn.Name = "savebtn";
			this.savebtn.Size = new System.Drawing.Size(75, 23);
			this.savebtn.TabIndex = 12;
			this.savebtn.Text = "Save";
			this.savebtn.UseVisualStyleBackColor = true;
			this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
			// 
			// cancelBtn
			// 
			this.cancelBtn.Location = new System.Drawing.Point(355, 310);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(75, 23);
			this.cancelBtn.TabIndex = 14;
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.UseVisualStyleBackColor = true;
			this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
			// 
			// textBoxCity
			// 
			this.textBoxCity.Location = new System.Drawing.Point(363, 155);
			this.textBoxCity.Name = "textBoxCity";
			this.textBoxCity.Size = new System.Drawing.Size(100, 20);
			this.textBoxCity.TabIndex = 19;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(293, 228);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 13);
			this.label3.TabIndex = 17;
			this.label3.Text = "Postal Code";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(293, 158);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(24, 13);
			this.label5.TabIndex = 16;
			this.label5.Text = "City";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(293, 88);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(38, 13);
			this.label7.TabIndex = 15;
			this.label7.Text = "Phone";
			// 
			// usernameLabel
			// 
			this.usernameLabel.AutoSize = true;
			this.usernameLabel.Location = new System.Drawing.Point(470, 10);
			this.usernameLabel.Name = "usernameLabel";
			this.usernameLabel.Size = new System.Drawing.Size(35, 13);
			this.usernameLabel.TabIndex = 21;
			this.usernameLabel.Text = "label8";
			// 
			// textBoxPhone
			// 
			this.textBoxPhone.Location = new System.Drawing.Point(363, 85);
			this.textBoxPhone.Mask = "000-0000";
			this.textBoxPhone.Name = "textBoxPhone";
			this.textBoxPhone.Size = new System.Drawing.Size(100, 20);
			this.textBoxPhone.TabIndex = 22;
			// 
			// textBoxP_Code
			// 
			this.textBoxP_Code.Location = new System.Drawing.Point(363, 225);
			this.textBoxP_Code.Mask = "00000";
			this.textBoxP_Code.Name = "textBoxP_Code";
			this.textBoxP_Code.Size = new System.Drawing.Size(100, 20);
			this.textBoxP_Code.TabIndex = 23;
			this.textBoxP_Code.ValidatingType = typeof(int);
			// 
			// addCustomer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(514, 451);
			this.Controls.Add(this.textBoxP_Code);
			this.Controls.Add(this.textBoxPhone);
			this.Controls.Add(this.usernameLabel);
			this.Controls.Add(this.textBoxCity);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.savebtn);
			this.Controls.Add(this.textBoxCountry);
			this.Controls.Add(this.textBoxAddress);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "addCustomer";
			this.Text = "Add Customer";
			this.Load += new System.EventHandler(this.addCustomer_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.TextBox textBoxAddress;
		private System.Windows.Forms.TextBox textBoxCountry;
		private System.Windows.Forms.Button savebtn;
		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.TextBox textBoxCity;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label usernameLabel;
		private System.Windows.Forms.MaskedTextBox textBoxPhone;
		private System.Windows.Forms.MaskedTextBox textBoxP_Code;
	}
}