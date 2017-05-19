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
        private TaskController taskController = new TaskController();
        private Shedule shedule;
        private string selectedDay, selectedTime;
        private uint userId;

        public AddTask(Shedule shedule, string selectedDay, string selectedTime, uint userId)
        {
            InitializeComponent();
            this.shedule = shedule;
            this.selectedDay = selectedDay;
            this.selectedTime = selectedTime;
            this.userId = userId;
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            shedule.title = txtTitle.Text;
            shedule.duration = Convert.ToByte(nudDuration.Value);
            shedule.label = txtLabel.Text;
            shedule.repeating = cbRepeating.Checked;
            taskController.Create(new Task() 
            {
                UserId = userId,
                Title  = txtTitle.Text, 
                Duration = Convert.ToByte(nudDuration.Value),
                Date = Convert.ToDateTime(selectedDay + " " + selectedTime),
                Label = txtLabel.Text,
                Repeats = Convert.ToByte(cbRepeating.Checked)
            });
            shedule.AddTaskToTable();
            this.Close();
        }
    }
}
