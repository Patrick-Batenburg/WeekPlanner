namespace SamenSterk.Views
{
    partial class AddTask
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblLabel = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.cbRepeating = new System.Windows.Forms.CheckBox();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(27, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Titel";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(133, 20);
            this.textBox1.TabIndex = 1;
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(12, 48);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(30, 13);
            this.lblDuration.TabIndex = 2;
            this.lblDuration.Text = "Duur";
            // 
            // lblLabel
            // 
            this.lblLabel.AutoSize = true;
            this.lblLabel.Location = new System.Drawing.Point(12, 87);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(33, 13);
            this.lblLabel.TabIndex = 3;
            this.lblLabel.Text = "Label";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(15, 64);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(133, 20);
            this.textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(15, 106);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(133, 20);
            this.textBox3.TabIndex = 5;
            // 
            // cbRepeating
            // 
            this.cbRepeating.AutoSize = true;
            this.cbRepeating.Location = new System.Drawing.Point(15, 133);
            this.cbRepeating.Name = "cbRepeating";
            this.cbRepeating.Size = new System.Drawing.Size(75, 17);
            this.cbRepeating.TabIndex = 6;
            this.cbRepeating.Text = "Herhalend";
            this.cbRepeating.UseVisualStyleBackColor = true;
            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(29, 156);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(107, 23);
            this.btnAddTask.TabIndex = 7;
            this.btnAddTask.Text = "Taak toevoegen";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // AddTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(160, 187);
            this.Controls.Add(this.btnAddTask);
            this.Controls.Add(this.cbRepeating);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.lblLabel);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddTask";
            this.ShowIcon = false;
            this.Text = "Taak Toevoegen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblLabel;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.CheckBox cbRepeating;
        private System.Windows.Forms.Button btnAddTask;
    }
}