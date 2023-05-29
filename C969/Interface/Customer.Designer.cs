
namespace C969
{
	partial class Customer_
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
			this.dgvCustomer = new System.Windows.Forms.DataGridView();
			this.addBtn = new System.Windows.Forms.Button();
			this.updtBtn = new System.Windows.Forms.Button();
			this.delBtn = new System.Windows.Forms.Button();
			this.exitBtn = new System.Windows.Forms.Button();
			this.signOutLbl = new System.Windows.Forms.LinkLabel();
			this.backBtn = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(25, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(86, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Customers";
			// 
			// dgvCustomer
			// 
			this.dgvCustomer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCustomer.Location = new System.Drawing.Point(16, 63);
			this.dgvCustomer.MultiSelect = false;
			this.dgvCustomer.Name = "dgvCustomer";
			this.dgvCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvCustomer.Size = new System.Drawing.Size(675, 259);
			this.dgvCustomer.TabIndex = 1;
			this.dgvCustomer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomer_CellClick);
			// 
			// addBtn
			// 
			this.addBtn.Location = new System.Drawing.Point(717, 93);
			this.addBtn.Name = "addBtn";
			this.addBtn.Size = new System.Drawing.Size(80, 46);
			this.addBtn.TabIndex = 2;
			this.addBtn.Text = "Add Customer";
			this.addBtn.UseVisualStyleBackColor = true;
			this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
			// 
			// updtBtn
			// 
			this.updtBtn.Location = new System.Drawing.Point(717, 180);
			this.updtBtn.Name = "updtBtn";
			this.updtBtn.Size = new System.Drawing.Size(80, 46);
			this.updtBtn.TabIndex = 3;
			this.updtBtn.Text = "Update Customer";
			this.updtBtn.UseVisualStyleBackColor = true;
			this.updtBtn.Click += new System.EventHandler(this.updtBtn_Click);
			// 
			// delBtn
			// 
			this.delBtn.Location = new System.Drawing.Point(717, 263);
			this.delBtn.Name = "delBtn";
			this.delBtn.Size = new System.Drawing.Size(80, 46);
			this.delBtn.TabIndex = 4;
			this.delBtn.Text = "Delete Customer";
			this.delBtn.UseVisualStyleBackColor = true;
			this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
			// 
			// exitBtn
			// 
			this.exitBtn.Location = new System.Drawing.Point(451, 354);
			this.exitBtn.Name = "exitBtn";
			this.exitBtn.Size = new System.Drawing.Size(80, 23);
			this.exitBtn.TabIndex = 6;
			this.exitBtn.Text = "Exit";
			this.exitBtn.UseVisualStyleBackColor = true;
			this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
			// 
			// signOutLbl
			// 
			this.signOutLbl.AutoSize = true;
			this.signOutLbl.Location = new System.Drawing.Point(770, 10);
			this.signOutLbl.Name = "signOutLbl";
			this.signOutLbl.Size = new System.Drawing.Size(48, 13);
			this.signOutLbl.TabIndex = 7;
			this.signOutLbl.TabStop = true;
			this.signOutLbl.Text = "Sign Out";
			this.signOutLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.signOutLbl_LinkClicked);
			// 
			// backBtn
			// 
			this.backBtn.Location = new System.Drawing.Point(54, 354);
			this.backBtn.Name = "backBtn";
			this.backBtn.Size = new System.Drawing.Size(120, 23);
			this.backBtn.TabIndex = 5;
			this.backBtn.Text = "Back";
			this.backBtn.UseVisualStyleBackColor = true;
			this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
			// 
			// Customer_
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(824, 416);
			this.Controls.Add(this.signOutLbl);
			this.Controls.Add(this.exitBtn);
			this.Controls.Add(this.backBtn);
			this.Controls.Add(this.delBtn);
			this.Controls.Add(this.updtBtn);
			this.Controls.Add(this.addBtn);
			this.Controls.Add(this.dgvCustomer);
			this.Controls.Add(this.label1);
			this.Name = "Customer_";
			this.Text = "View Customers";
			this.Load += new System.EventHandler(this.Customer__Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button addBtn;
		private System.Windows.Forms.Button updtBtn;
		private System.Windows.Forms.Button delBtn;
		private System.Windows.Forms.Button exitBtn;
		private System.Windows.Forms.LinkLabel signOutLbl;
		private System.Windows.Forms.Button backBtn;
		public System.Windows.Forms.DataGridView dgvCustomer;
	}
}