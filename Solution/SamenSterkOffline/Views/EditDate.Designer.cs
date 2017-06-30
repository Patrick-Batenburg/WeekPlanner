namespace SamenSterkOffline.Views
{
	partial class EditDate
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnEditSchedule = new System.Windows.Forms.Button();
			this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.lblStartDate = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.BackColor = System.Drawing.Color.Orchid;
			this.btnCancel.FlatAppearance.BorderSize = 0;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.ForeColor = System.Drawing.Color.White;
			this.btnCancel.Location = new System.Drawing.Point(8, 55);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(78, 25);
			this.btnCancel.TabIndex = 18;
			this.btnCancel.Text = "Annuleer";
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnEditSchedule
			// 
			this.btnEditSchedule.BackColor = System.Drawing.Color.Orchid;
			this.btnEditSchedule.FlatAppearance.BorderSize = 0;
			this.btnEditSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnEditSchedule.ForeColor = System.Drawing.Color.White;
			this.btnEditSchedule.Location = new System.Drawing.Point(98, 55);
			this.btnEditSchedule.Name = "btnEditSchedule";
			this.btnEditSchedule.Size = new System.Drawing.Size(78, 25);
			this.btnEditSchedule.TabIndex = 17;
			this.btnEditSchedule.Text = "Wijzigen";
			this.btnEditSchedule.UseVisualStyleBackColor = false;
			this.btnEditSchedule.Click += new System.EventHandler(this.btnEditSchedule_Click);
			// 
			// startDateTimePicker
			// 
			this.startDateTimePicker.Location = new System.Drawing.Point(8, 27);
			this.startDateTimePicker.Name = "startDateTimePicker";
			this.startDateTimePicker.Size = new System.Drawing.Size(168, 20);
			this.startDateTimePicker.TabIndex = 19;
			this.startDateTimePicker.ValueChanged += new System.EventHandler(this.startDateTimePicker_ValueChanged);
			// 
			// lblStartDate
			// 
			this.lblStartDate.AutoSize = true;
			this.lblStartDate.Location = new System.Drawing.Point(8, 10);
			this.lblStartDate.Name = "lblStartDate";
			this.lblStartDate.Size = new System.Drawing.Size(62, 14);
			this.lblStartDate.TabIndex = 20;
			this.lblStartDate.Text = "Start datum";
			// 
			// EditDate
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(184, 85);
			this.Controls.Add(this.lblStartDate);
			this.Controls.Add(this.startDateTimePicker);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnEditSchedule);
			this.Font = new System.Drawing.Font("Arial", 8.25F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EditDate";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Wijzig datum";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnEditSchedule;
		private System.Windows.Forms.DateTimePicker startDateTimePicker;
		private System.Windows.Forms.Label lblStartDate;
	}
}