using SamenSterkOnline.Controllers;
using SamenSterkOnline.Models;
using System;
using System.Windows.Forms;

namespace SamenSterkOnline.Views
{
    public partial class EditTask : Form
    {
        private TaskController taskController;
        private RepeatingTaskController repeatingTaskController;
        private Task taskModel;
        private RepeatingTask repeatingTaskModel;
        private int result;
        private DateTime dateTime;

        /// <summary>
        /// Initializes a new instance of the form EditTask class.
        /// </summary>
        /// <param name="shedule">Details of the shedule.</param>
        /// <param name="model">Task details to edit.</param>
        /// <param name="dateTime">DateTime to edit.</param>
        public EditTask(Task model, DateTime dateTime)
        {
            InitializeComponent();
            this.dateTime = dateTime;
            this.taskModel = new Task()
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
        /// <param name="dateTime">DateTime to edit.</param>
        public EditTask(RepeatingTask model, DateTime dateTime)
        {
            InitializeComponent();
            this.dateTime = dateTime;
            this.repeatingTaskModel = new RepeatingTask()
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

        /// <summary>
        /// Occurs when the Button control is clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param> 
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

            if (Convert.ToByte(nudDuration.Value) + dateTime.Hour > 24)
            {
                nudDuration.Value = 24 - dateTime.Hour;
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
                    if (taskModel != null)
                    {
                        this.taskModel.Duration = Convert.ToByte(nudDuration.Value);
                        this.taskModel.Title = txtTitle.Text;
                        this.taskModel.Label = txtLabel.Text;
                        result = taskController.Exceeds(taskModel);

                        if (result != 0 && result != 2)
                        {
                            result = taskController.Edit(taskModel);
                        }
                    }
                    else
                    {
                        Task task = new Task()
                        {
                            UserId = repeatingTaskModel.UserId,
                            Title = txtTitle.Text,
                            Date = dateTime,
                            Duration = Convert.ToByte(nudDuration.Value),
                            Label = txtLabel.Text
                        };
                        repeatingTaskController.Delete(repeatingTaskModel);
                        result = taskController.Exceeds(task);

                        if (result != 0 && result != 2)
                        {
                            result = taskController.Create(task);
                        }
                    }
                }
                else
                {
                    if (repeatingTaskModel != null)
                    {
                        this.repeatingTaskModel.Duration = Convert.ToByte(nudDuration.Value);
                        this.repeatingTaskModel.Title = txtTitle.Text;
                        this.repeatingTaskModel.Label = txtLabel.Text;
                        this.repeatingTaskModel.Time = dateTime.TimeOfDay;
                        result = repeatingTaskController.Exceeds(repeatingTaskModel);

                        if (result != 0 && result != 2)
                        {
                            result = repeatingTaskController.Edit(repeatingTaskModel);
                        }
                    }
                    else
                    {
                        RepeatingTask repeatingTask = new RepeatingTask()
                        {
                            UserId = taskModel.UserId,
                            Title = txtTitle.Text,
                            Day = dateTime.ToString("dddd"),
                            Time = dateTime.TimeOfDay,
                            Duration = Convert.ToByte(nudDuration.Value),
                            Label = txtLabel.Text
                        };
                        taskController.Delete(taskModel);
                        result = repeatingTaskController.Exceeds(repeatingTask);

                        if (result != 0 && result != 2)
                        {
                            result = repeatingTaskController.Create(repeatingTask);
                        }
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

        /// <summary>
        /// Occurs when the Button control is clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param> 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Weet je het zeker?", "Taak verwijderen", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                if (taskModel != null)
                {
                    taskController.Delete(taskModel);
                }
                if (repeatingTaskModel != null)
                {
                    repeatingTaskController.Delete(repeatingTaskModel);
                }
                this.Close();
            }
        }
    }
}