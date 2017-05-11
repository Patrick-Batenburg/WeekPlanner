namespace SamenSterk.Views
{
    partial class frmShedule
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
            this.btnLogout = new System.Windows.Forms.Button();
            this.dgvShedule = new System.Windows.Forms.DataGridView();
            this.columnDay1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDay2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDay3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDay4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDay5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDay6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDay7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabShedule = new System.Windows.Forms.TabPage();
            this.tabGrades = new System.Windows.Forms.TabPage();
            this.dgvGrades = new System.Windows.Forms.DataGridView();
            this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnGrade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabAppointments = new System.Windows.Forms.TabPage();
            this.cbUsernames = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShedule)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabShedule.SuspendLayout();
            this.tabGrades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(12, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(74, 23);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Uitloggen";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // dgvShedule
            // 
            this.dgvShedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnDay1,
            this.columnDay2,
            this.columnDay3,
            this.columnDay4,
            this.columnDay5,
            this.columnDay6,
            this.columnDay7});
            this.dgvShedule.Location = new System.Drawing.Point(0, 0);
            this.dgvShedule.Name = "dgvShedule";
            this.dgvShedule.ReadOnly = true;
            this.dgvShedule.Size = new System.Drawing.Size(782, 397);
            this.dgvShedule.TabIndex = 1;
            this.dgvShedule.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShedule_CellClick);
            // 
            // columnDay1
            // 
            this.columnDay1.HeaderText = "Maandag";
            this.columnDay1.Name = "columnDay1";
            this.columnDay1.ReadOnly = true;
            // 
            // columnDay2
            // 
            this.columnDay2.HeaderText = "Dinsdag";
            this.columnDay2.Name = "columnDay2";
            this.columnDay2.ReadOnly = true;
            // 
            // columnDay3
            // 
            this.columnDay3.HeaderText = "Woensdag";
            this.columnDay3.Name = "columnDay3";
            this.columnDay3.ReadOnly = true;
            // 
            // columnDay4
            // 
            this.columnDay4.HeaderText = "Donderdag";
            this.columnDay4.Name = "columnDay4";
            this.columnDay4.ReadOnly = true;
            // 
            // columnDay5
            // 
            this.columnDay5.HeaderText = "Vrijdag";
            this.columnDay5.Name = "columnDay5";
            this.columnDay5.ReadOnly = true;
            // 
            // columnDay6
            // 
            this.columnDay6.HeaderText = "Zaterdag";
            this.columnDay6.Name = "columnDay6";
            this.columnDay6.ReadOnly = true;
            // 
            // columnDay7
            // 
            this.columnDay7.HeaderText = "Zondag";
            this.columnDay7.Name = "columnDay7";
            this.columnDay7.ReadOnly = true;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabShedule);
            this.tabControl.Controls.Add(this.tabGrades);
            this.tabControl.Controls.Add(this.tabAppointments);
            this.tabControl.Location = new System.Drawing.Point(102, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(790, 423);
            this.tabControl.TabIndex = 2;
            // 
            // tabShedule
            // 
            this.tabShedule.Controls.Add(this.dgvShedule);
            this.tabShedule.Location = new System.Drawing.Point(4, 22);
            this.tabShedule.Name = "tabShedule";
            this.tabShedule.Padding = new System.Windows.Forms.Padding(3);
            this.tabShedule.Size = new System.Drawing.Size(782, 397);
            this.tabShedule.TabIndex = 0;
            this.tabShedule.Text = "Rooster";
            this.tabShedule.UseVisualStyleBackColor = true;
            // 
            // tabGrades
            // 
            this.tabGrades.Controls.Add(this.dgvGrades);
            this.tabGrades.Location = new System.Drawing.Point(4, 22);
            this.tabGrades.Name = "tabGrades";
            this.tabGrades.Padding = new System.Windows.Forms.Padding(3);
            this.tabGrades.Size = new System.Drawing.Size(782, 397);
            this.tabGrades.TabIndex = 1;
            this.tabGrades.Text = "Cijfers";
            this.tabGrades.UseVisualStyleBackColor = true;
            // 
            // dgvGrades
            // 
            this.dgvGrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnName,
            this.columnGrade});
            this.dgvGrades.Location = new System.Drawing.Point(-4, -3);
            this.dgvGrades.Name = "dgvGrades";
            this.dgvGrades.Size = new System.Drawing.Size(786, 400);
            this.dgvGrades.TabIndex = 0;
            // 
            // columnName
            // 
            this.columnName.HeaderText = "Name";
            this.columnName.Name = "columnName";
            // 
            // columnGrade
            // 
            this.columnGrade.HeaderText = "Grades";
            this.columnGrade.Name = "columnGrade";
            // 
            // tabAppointments
            // 
            this.tabAppointments.Location = new System.Drawing.Point(4, 22);
            this.tabAppointments.Name = "tabAppointments";
            this.tabAppointments.Padding = new System.Windows.Forms.Padding(3);
            this.tabAppointments.Size = new System.Drawing.Size(782, 397);
            this.tabAppointments.TabIndex = 2;
            this.tabAppointments.Text = "Belangrijke Afspraken";
            this.tabAppointments.UseVisualStyleBackColor = true;
            // 
            // cbUsernames
            // 
            this.cbUsernames.FormattingEnabled = true;
            this.cbUsernames.Location = new System.Drawing.Point(12, 160);
            this.cbUsernames.Name = "cbUsernames";
            this.cbUsernames.Size = new System.Drawing.Size(88, 21);
            this.cbUsernames.TabIndex = 3;
            // 
            // frmShedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 447);
            this.Controls.Add(this.cbUsernames);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.tabControl);
            this.Name = "frmShedule";
            this.Text = "Shedule";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Shedule_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShedule)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabShedule.ResumeLayout(false);
            this.tabGrades.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.DataGridView dgvShedule;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabGrades;
        private System.Windows.Forms.TabPage tabShedule;
        private System.Windows.Forms.TabPage tabAppointments;
        private System.Windows.Forms.ComboBox cbUsernames;
        private System.Windows.Forms.DataGridView dgvGrades;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnGrade;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDay1;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDay2;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDay3;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDay4;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDay5;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDay6;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDay7;
    }
}