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
    public partial class AddTask : Form
    {
        TaskController taskController = new TaskController();
        Shedule shedule;
        public AddTask(Shedule shedule)
        {
            this.shedule = shedule;
            InitializeComponent();
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            shedule.title = txtTitle.Text;
            shedule.duration = Convert.ToByte(nudDuration.Value);
            shedule.label = txtLabel.Text;
            shedule.repeating = cbRepeating.Checked;
            taskController.Create(new Task() { 
                Title  = txtTitle.Text, 
                Duration = Convert.ToByte(nudDuration.Value), 
                Label = txtLabel.Text,
                Repeats = Convert.ToByte(cbRepeating.Checked) });
            shedule.AddTaskToTable();
            this.Close();
        }
    }
}
