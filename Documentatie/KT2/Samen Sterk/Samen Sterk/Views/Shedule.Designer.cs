namespace SamenSterk.Views
{
    partial class Shedule
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
            this.Day1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Day2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Day3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Day4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Day5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Day6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Day7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.TabShedule = new System.Windows.Forms.TabPage();
            this.tabGrades = new System.Windows.Forms.TabPage();
            this.dgvGrades = new System.Windows.Forms.DataGridView();
            this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnGrade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabAppointments = new System.Windows.Forms.TabPage();
            this.cbUsernames = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShedule)).BeginInit();
            this.tabControl.SuspendLayout();
            this.TabShedule.SuspendLayout();
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
            this.Day1,
            this.Day2,
            this.Day3,
            this.Day4,
            this.Day5,
            this.Day6,
            this.Day7});
            this.dgvShedule.Location = new System.Drawing.Point(0, 0);
            this.dgvShedule.Name = "dgvShedule";
            this.dgvShedule.Size = new System.Drawing.Size(782, 397);
            this.dgvShedule.TabIndex = 1;
            this.dgvShedule.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShedule_CellClick);
            // 
            // Day1
            // 
            this.Day1.HeaderText = "Maandag";
            this.Day1.Name = "Day1";
            // 
            // Day2
            // 
            this.Day2.HeaderText = "Dinsdag";
            this.Day2.Name = "Day2";
            // 
            // Day3
            // 
            this.Day3.HeaderText = "Woensdag";
            this.Day3.Name = "Day3";
            // 
            // Day4
            // 
            this.Day4.HeaderText = "Donderdag";
            this.Day4.Name = "Day4";
            // 
            // Day5
            // 
            this.Day5.HeaderText = "Vrijdag";
            this.Day5.Name = "Day5";
            // 
            // Day6
            // 
            this.Day6.HeaderText = "Zaterdag";
            this.Day6.Name = "Day6";
            // 
            // Day7
            // 
            this.Day7.HeaderText = "Zondag";
            this.Day7.Name = "Day7";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.TabShedule);
            this.tabControl.Controls.Add(this.tabGrades);
            this.tabControl.Controls.Add(this.tabAppointments);
            this.tabControl.Location = new System.Drawing.Point(102, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(790, 423);
            this.tabControl.TabIndex = 2;
            // 
            // TabShedule
            // 
            this.TabShedule.Controls.Add(this.dgvShedule);
            this.TabShedule.Location = new System.Drawing.Point(4, 22);
            this.TabShedule.Name = "TabShedule";
            this.TabShedule.Padding = new System.Windows.Forms.Padding(3);
            this.TabShedule.Size = new System.Drawing.Size(782, 397);
            this.TabShedule.TabIndex = 0;
            this.TabShedule.Text = "Rooster";
            this.TabShedule.UseVisualStyleBackColor = true;
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
            // Shedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 447);
            this.Controls.Add(this.cbUsernames);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.tabControl);
            this.Name = "Shedule";
            this.Text = "Shedule";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Shedule_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShedule)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.TabShedule.ResumeLayout(false);
            this.tabGrades.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.DataGridView dgvShedule;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabGrades;
        private System.Windows.Forms.TabPage TabShedule;
        private System.Windows.Forms.TabPage tabAppointments;
        private System.Windows.Forms.ComboBox cbUsernames;
        private System.Windows.Forms.DataGridView dgvGrades;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnGrade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Day1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Day2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Day3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Day4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Day5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Day6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Day7;
    }
}