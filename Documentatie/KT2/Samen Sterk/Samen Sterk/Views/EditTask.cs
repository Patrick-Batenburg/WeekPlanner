using SamenSterk.Controllers;
using SamenSterk.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SamenSterk.Views
{
    public partial class EditTask : Form
    {
        private TaskController taskController = new TaskController();
        private Task task;
        private Shedule shedule;

        public EditTask(Shedule shedule, string title, byte duration, string label, byte repeats)
        {
            InitializeComponent();
            this.shedule = shedule;
            txtTitle.Text = title;
            nudDuration.Value = duration;
            txtLabel.Text = label;
            cbRepeating.Checked = Convert.ToBoolean(repeats);
        }

        private void btnEditTask_Click(object sender, EventArgs e)
        {
            shedule.title = txtTitle.Text;
            shedule.duration = Convert.ToByte(nudDuration.Value);
            shedule.label = txtLabel.Text;
            shedule.repeating = cbRepeating.Checked;
            taskController.Edit(new Task()
            {
                Title = txtTitle.Text, 
                Duration = Convert.ToByte(nudDuration.Value), 
                Label = txtLabel.Text, 
                Repeats = Convert.ToByte(cbRepeating.Checked)
            });
            shedule.AddTaskToTable();
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Weet je het zeker?", "Taak verwijderen", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                taskController.Delete(task);
                shedule.DeleteTaskFromTable();
                this.Close();
            }
        }
    }
}
