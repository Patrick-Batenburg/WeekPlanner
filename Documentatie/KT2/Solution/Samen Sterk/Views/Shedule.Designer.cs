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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Shedule));
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
            this.lblInsertName = new System.Windows.Forms.Label();
            this.txtSubjectName = new System.Windows.Forms.TextBox();
            this.btnAddSubject = new System.Windows.Forms.Button();
            this.dgvGrades = new System.Windows.Forms.DataGridView();
            this.tabAppointments = new System.Windows.Forms.TabPage();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.columnName2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbUsernames = new System.Windows.Forms.ComboBox();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblViewUser = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShedule)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabShedule.SuspendLayout();
            this.tabGrades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).BeginInit();
            this.tabAppointments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Orchid;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(13, 37);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(74, 25);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Uitloggen";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // dgvShedule
            // 
            this.dgvShedule.AllowUserToAddRows = false;
            this.dgvShedule.AllowUserToDeleteRows = false;
            this.dgvShedule.AllowUserToResizeColumns = false;
            this.dgvShedule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.dgvShedule.RowHeadersWidth = 70;
            this.dgvShedule.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvShedule.Size = new System.Drawing.Size(776, 426);
            this.dgvShedule.TabIndex = 1;
            this.dgvShedule.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShedule_CellDoubleClick);
            this.dgvShedule.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvShedule_ColumnHeaderMouseDoubleClick_1);
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
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabShedule);
            this.tabControl.Controls.Add(this.tabGrades);
            this.tabControl.Controls.Add(this.tabAppointments);
            this.tabControl.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tabControl.Location = new System.Drawing.Point(102, 13);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(781, 456);
            this.tabControl.TabIndex = 2;
            this.tabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl_Selected);
            // 
            // tabShedule
            // 
            this.tabShedule.Controls.Add(this.dgvShedule);
            this.tabShedule.Location = new System.Drawing.Point(4, 23);
            this.tabShedule.Name = "tabShedule";
            this.tabShedule.Padding = new System.Windows.Forms.Padding(3);
            this.tabShedule.Size = new System.Drawing.Size(773, 429);
            this.tabShedule.TabIndex = 0;
            this.tabShedule.Text = "Rooster";
            this.tabShedule.UseVisualStyleBackColor = true;
            // 
            // tabGrades
            // 
            this.tabGrades.Controls.Add(this.lblInsertName);
            this.tabGrades.Controls.Add(this.txtSubjectName);
            this.tabGrades.Controls.Add(this.btnAddSubject);
            this.tabGrades.Controls.Add(this.dgvGrades);
            this.tabGrades.Location = new System.Drawing.Point(4, 23);
            this.tabGrades.Name = "tabGrades";
            this.tabGrades.Padding = new System.Windows.Forms.Padding(3);
            this.tabGrades.Size = new System.Drawing.Size(773, 429);
            this.tabGrades.TabIndex = 1;
            this.tabGrades.Text = "Cijfers";
            this.tabGrades.UseVisualStyleBackColor = true;
            // 
            // lblInsertName
            // 
            this.lblInsertName.AutoSize = true;
            this.lblInsertName.ForeColor = System.Drawing.Color.Red;
            this.lblInsertName.Location = new System.Drawing.Point(195, 13);
            this.lblInsertName.Name = "lblInsertName";
            this.lblInsertName.Size = new System.Drawing.Size(91, 14);
            this.lblInsertName.TabIndex = 3;
            this.lblInsertName.Text = "Voer een naam in";
            this.lblInsertName.Visible = false;
            // 
            // txtSubjectName
            // 
            this.txtSubjectName.Location = new System.Drawing.Point(6, 6);
            this.txtSubjectName.Name = "txtSubjectName";
            this.txtSubjectName.Size = new System.Drawing.Size(85, 20);
            this.txtSubjectName.TabIndex = 2;
            // 
            // btnAddSubject
            // 
            this.btnAddSubject.BackColor = System.Drawing.Color.Orchid;
            this.btnAddSubject.FlatAppearance.BorderSize = 0;
            this.btnAddSubject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSubject.ForeColor = System.Drawing.Color.White;
            this.btnAddSubject.Location = new System.Drawing.Point(97, 5);
            this.btnAddSubject.Name = "btnAddSubject";
            this.btnAddSubject.Size = new System.Drawing.Size(91, 25);
            this.btnAddSubject.TabIndex = 1;
            this.btnAddSubject.Text = "Vak toevoegen";
            this.btnAddSubject.UseVisualStyleBackColor = false;
            this.btnAddSubject.Click += new System.EventHandler(this.btnAddSubject_Click);
            // 
            // dgvGrades
            // 
            this.dgvGrades.AllowUserToAddRows = false;
            this.dgvGrades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrades.ColumnHeadersVisible = false;
            this.dgvGrades.Location = new System.Drawing.Point(-4, 38);
            this.dgvGrades.Name = "dgvGrades";
            this.dgvGrades.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvGrades.Size = new System.Drawing.Size(786, 389);
            this.dgvGrades.TabIndex = 0;
            this.dgvGrades.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvGrades_RowHeaderMouseDoubleClick);
            this.dgvGrades.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvGrades_MouseUp);
            // 
            // tabAppointments
            // 
            this.tabAppointments.Controls.Add(this.dgvAppointments);
            this.tabAppointments.Location = new System.Drawing.Point(4, 23);
            this.tabAppointments.Name = "tabAppointments";
            this.tabAppointments.Padding = new System.Windows.Forms.Padding(3);
            this.tabAppointments.Size = new System.Drawing.Size(773, 429);
            this.tabAppointments.TabIndex = 2;
            this.tabAppointments.Text = "Belangrijke Afspraken";
            this.tabAppointments.UseVisualStyleBackColor = true;
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnName2,
            this.columnDate});
            this.dgvAppointments.Location = new System.Drawing.Point(0, 0);
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvAppointments.Size = new System.Drawing.Size(782, 426);
            this.dgvAppointments.TabIndex = 0;
            // 
            // columnName2
            // 
            this.columnName2.HeaderText = "Naam";
            this.columnName2.Name = "columnName2";
            // 
            // columnDate
            // 
            this.columnDate.HeaderText = "Datum";
            this.columnDate.Name = "columnDate";
            this.columnDate.Width = 150;
            // 
            // cbUsernames
            // 
            this.cbUsernames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUsernames.FormattingEnabled = true;
            this.cbUsernames.Location = new System.Drawing.Point(8, 182);
            this.cbUsernames.Name = "cbUsernames";
            this.cbUsernames.Size = new System.Drawing.Size(88, 22);
            this.cbUsernames.TabIndex = 3;
            this.cbUsernames.SelectedIndexChanged += new System.EventHandler(this.cbUsernames_SelectedIndexChanged);
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.Orchid;
            this.btnPrevious.FlatAppearance.BorderSize = 0;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btnPrevious.ForeColor = System.Drawing.Color.White;
            this.btnPrevious.Location = new System.Drawing.Point(12, 86);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 25);
            this.btnPrevious.TabIndex = 2;
            this.btnPrevious.Text = "Vorige";
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Orchid;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(12, 117);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 25);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "Volgende";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblViewUser
            // 
            this.lblViewUser.AutoSize = true;
            this.lblViewUser.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblViewUser.Location = new System.Drawing.Point(5, 165);
            this.lblViewUser.Name = "lblViewUser";
            this.lblViewUser.Size = new System.Drawing.Size(85, 14);
            this.lblViewUser.TabIndex = 5;
            this.lblViewUser.Text = "Gebruiker inzien";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(13, 14);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(86, 14);
            this.lblUsername.TabIndex = 6;
            this.lblUsername.Text = "Gebruikersnaam";
            // 
            // Shedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(891, 481);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblViewUser);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.cbUsernames);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(340, 240);
            this.Name = "Shedule";
            this.Text = "Samen Sterk";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Shedule_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShedule)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabShedule.ResumeLayout(false);
            this.tabGrades.ResumeLayout(false);
            this.tabGrades.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).EndInit();
            this.tabAppointments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDay1;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDay2;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDay3;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDay4;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDay5;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDay6;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDay7;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.Button btnAddSubject;
        private System.Windows.Forms.TextBox txtSubjectName;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblInsertName;
        private System.Windows.Forms.Label lblViewUser;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName2;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDate;
    }
}