using SamenSterkOnline.Controllers;
using SamenSterkOnline.Models;
using System;
using System.Windows.Forms;

namespace SamenSterkOnline.Views
{
    public partial class AddTask : Form
    {
        private TaskController taskController;
        private uint userId;
        private DateTime dateTime;
        private RepeatingTaskController repeatingTaskController;
        private int result;
        private RepeatingTask repeatingTask;
        private Task task;

        /// <summary>
        /// Initializes a new instance of the form AddTask class.
        /// </summary>
        /// <param name="dateTime">DateTime of the task.</param>
        /// <param name="userId">Id of the user who initiated AddTask.</param>
        public AddTask(DateTime dateTime, uint userId)
        {
            InitializeComponent();
            this.dateTime = dateTime;
            this.userId = userId;
            taskController = new TaskController();
            repeatingTaskController = new RepeatingTaskController();
            result = 0;
        }

        /// <summary>
        /// Occurs when the Button control is clicked. Adds a new Task or RepeatingTask.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

            if (txtTitle.Text.Length > 64)
            {
                MessageBox.Show("Titel is te lang.");
            }
            else if (txtLabel.Text.Length > 64)
            {
                MessageBox.Show("Label is te lang.");
            }
            else
            {
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
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Kan de taak niet toevoegen. De tijd overlapt over een andere taak.");
                }
            }
        }
    }
}