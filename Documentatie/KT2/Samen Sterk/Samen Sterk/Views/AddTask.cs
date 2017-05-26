using SamenSterk.Controllers;
using SamenSterk.Models;
using System;
using System.Windows.Forms;

namespace SamenSterk.Views
{
    public partial class AddTask : Form
    {
        private TaskController taskController;
        private Shedule shedule;
        private uint userId;
        private DateTime dateTime;
        private RepeatingTaskController repeatingTaskController;
        private int result;
        private RepeatingTask repeatingTask;
        private Task task;

        public AddTask(Shedule shedule, DateTime dateTime, uint userId)
        {
            InitializeComponent();
            this.shedule = shedule;
            this.dateTime = dateTime;
            this.userId = userId;
            taskController = new TaskController();
            repeatingTaskController = new RepeatingTaskController();
            result = 0;
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                txtTitle.Text = "[Geen titel]";
            }

            if (Convert.ToByte(nudDuration.Value) == 0)
            {
                nudDuration.Value = 1;
            }

            if (cbRepeating.Checked == false)
            {
                task = new Task()
                {
                    UserId = userId,
                    Title = txtTitle.Text,
                    Duration = Convert.ToByte(nudDuration.Value),
                    Date = Convert.ToDateTime(dateTime),
                    Label = txtLabel.Text,
                };

                result = taskController.Exceeds(task);
                if (result != 0 && result != 2)
                {
                    result = taskController.Create(task);
                }
            }
            else
            {
                repeatingTask = new RepeatingTask()
                {
                    UserId = userId,
                    Title = txtTitle.Text,
                    Day = dateTime.ToString("dddd"),
                    Time = dateTime.TimeOfDay,
                    Duration = Convert.ToByte(nudDuration.Value),
                    Label = txtLabel.Text
                };

                result = repeatingTaskController.Exceeds(repeatingTask);
                if (result != 0 && result != 2)
                {
                    result = repeatingTaskController.Create(repeatingTask);
                }
            }

            if (result != 2)
            {
                shedule.LoadToGrid(typeof(Task));
                this.Close();
            }
            else
            {
                MessageBox.Show("Kan de taak niet toevoegen. De tijd overlapt over een andere taak.");
            }
        }
    }
}