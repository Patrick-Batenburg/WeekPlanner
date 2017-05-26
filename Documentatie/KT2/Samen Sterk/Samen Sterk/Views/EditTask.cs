using SamenSterk.Controllers;
using SamenSterk.Models;
using System;
using System.Windows.Forms;

namespace SamenSterk.Views
{
    public partial class EditTask : Form
    {
        private TaskController taskController;
        private RepeatingTaskController repeatingTaskController;
        private Shedule shedule;
        private Task task;
        private int result;
        private RepeatingTask repeatingTask;
        private DateTime dateTime;

        /// <summary>
        /// Initializes a new instance of the form EditTask class.
        /// </summary>
        /// <param name="shedule">Details of the shedule to edit.</param>
        /// <param name="model">Task details to edit.</param>
        public EditTask(Shedule shedule, Task model, DateTime dateTime)
        {
            InitializeComponent();
            this.shedule = shedule;
            this.dateTime = dateTime;
            this.task = new Task()
            {
                Id = model.Id,
                UserId = model.UserId,
                Title = model.Title,
                Date = dateTime,
                Duration = model.Duration,
                Label = model.Label
            };
            taskController = new TaskController();
            repeatingTaskController = new RepeatingTaskController();
            txtTitle.Text = model.Title;
            nudDuration.Value = model.Duration;
            txtLabel.Text = model.Label;
            result = 0;
        }

        /// <summary>
        /// Initializes a new instance of the form EditTask class.
        /// </summary>
        /// <param name="shedule">Details of the shedule to edit.</param>
        /// <param name="model">Repeating task details to edit.</param>
        public EditTask(Shedule shedule, RepeatingTask model, DateTime dateTime)
        {
            InitializeComponent();
            this.shedule = shedule;
            this.dateTime = dateTime;
            this.repeatingTask = new RepeatingTask()
            {
                Id = model.Id,
                UserId = model.UserId,
                Title = model.Title,
                Day = dateTime.ToString("dddd"),
                Time = model.Time,
                Duration = model.Duration,
                Label = model.Label
            };
            taskController = new TaskController();
            repeatingTaskController = new RepeatingTaskController();
            txtTitle.Text = model.Title;
            nudDuration.Value = model.Duration;
            txtLabel.Text = model.Label;
            cbRepeating.Checked = true;
            result = 0;
        }

        private void btnEditTask_Click(object sender, EventArgs e)
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
                if (task != null)
                {
                    this.task.Duration = Convert.ToByte(nudDuration.Value);
                    this.task.Title = txtTitle.Text;
                    this.task.Label = txtLabel.Text;
                    result = taskController.Exceeds(task);

                    if (result != 0 && result != 2)
                    {
                        result = taskController.Edit(task);
                    }
                }
                else
                {
                    task = new Task()
                    {
                        UserId = repeatingTask.UserId,
                        Title = txtTitle.Text,
                        Date = dateTime,
                        Duration = Convert.ToByte(nudDuration.Value),
                        Label = txtLabel.Text
                    };
                    repeatingTaskController.Delete(repeatingTask);
                    result = taskController.Exceeds(task);

                    if (result != 0 && result != 2)
                    {
                        result = taskController.Create(task);
                    }
                }
            }
            else
            {
                if (repeatingTask != null)
                {
                    this.repeatingTask.Duration = Convert.ToByte(nudDuration.Value);
                    this.repeatingTask.Title = txtTitle.Text;
                    this.repeatingTask.Label = txtLabel.Text;
                    this.repeatingTask.Time = dateTime.TimeOfDay;
                    result = repeatingTaskController.Exceeds(repeatingTask);

                    if (result != 0 && result != 2)
                    {
                        result = repeatingTaskController.Edit(repeatingTask);
                    }
                }
                else
                {
                    repeatingTask = new RepeatingTask()
                    {
                        UserId = task.UserId,
                        Title = txtTitle.Text,
                        Day = dateTime.ToString("dddd"),
                        Time = dateTime.TimeOfDay,
                        Duration = Convert.ToByte(nudDuration.Value),
                        Label = txtLabel.Text
                    };
                    taskController.Delete(task);
                    result = repeatingTaskController.Exceeds(repeatingTask);

                    if (result != 0 && result != 2)
                    {
                        result = repeatingTaskController.Create(repeatingTask);
                    }
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Weet je het zeker?", "Taak verwijderen", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                shedule.DeleteFromGrid(typeof(Task));
                this.Close();
            }
        }
    }
}