using SamenSterk.Controllers;
using SamenSterk.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SamenSterk.Views
{
    public partial class Shedule : Form
    {
        public DateTime startDate;
        public User currentUser;
        public User selectedUser;
        private int[] cellPos;
        private bool logout;
        private List<Task> tasks;
        private List<RepeatingTask> repeatingTasks;
        private TaskController taskController;
        private RepeatingTaskController repeatingTaskController;
        private UserController userController;

        public Shedule(User user)
        {
            InitializeComponent();
            tasks = new List<Task>();
            repeatingTasks = new List<RepeatingTask>();
            userController = new UserController();
            taskController = new TaskController();
            repeatingTaskController = new RepeatingTaskController();
            cellPos = new int[] { 0, 0 };

            this.currentUser = user;
            this.selectedUser = currentUser;
            dgvShedule.AutoGenerateColumns = false;
            tasks = taskController.Details(user.Id);
            repeatingTasks = repeatingTaskController.Details(user.Id);

            this.FormClosing += Shedule_FormClosing;
            dgvShedule.ColumnHeaderMouseDoubleClick += dgvShedule_ColumnHeaderMouseDoubleClick;

            for (int i = 0; i < 7; i++)
            {
                dgvShedule.Columns[i].HeaderText = DateTime.Today.AddDays(i).ToString("dd-MM-yyyy");
            }

            if (user.Role != "Admin")
            {
                lblViewUser.Visible = false;
                cbUsernames.Visible = false;
            }
            else
            {
                cbUsernames.Click += cbUsernames_Click;
                lblViewUser.Visible = true;
                cbUsernames.Visible = true;
                cbUsernames.Items.Add("Ik");
                cbUsernames.DropDownStyle = ComboBoxStyle.DropDownList;
                cbUsernames.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Determine which type to load into the DataGridView.
        /// </summary>
        /// <param name="obj">Typeof the object.</param>
        public void LoadToGrid(Type obj)
        {
            byte rowIndex = 0;
            byte columnIndex = 0;

            switch (obj.ToString())
            {
                case "SamenSterk.Models.Task":
                    dgvShedule.Rows.Clear();

                    for (int i = 0; i < 17; i++)
                    {
                        dgvShedule.Rows.Add();
                        dgvShedule.Rows[i].HeaderCell.Value = (7 + i) + ":00";
                    }

                    List<Task> taskQuery = (from task in tasks
                                            where task.Date >= Convert.ToDateTime(dgvShedule.Columns[0].HeaderText) && task.Date <= Convert.ToDateTime(dgvShedule.Columns[6].HeaderText)
                                            select task).ToList();

                    if (taskQuery.Count != 0)
                    {
                        foreach (var element in taskQuery)
                        {
                            for (byte i = 0; i < 17; i++)
                            {
                                if (dgvShedule.Rows[i].HeaderCell.Value.ToString() == element.Date.ToString("H:mm"))
                                {
                                    rowIndex = i;
                                }
                            }

                            for (byte i = 0; i < 7; i++)
                            {
                                if (dgvShedule.Columns[i].HeaderText == element.Date.ToString("dd-MM-yyyy"))
                                {
                                    columnIndex = i;
                                }
                            }

                            dgvShedule.Rows[rowIndex].Cells[columnIndex].Value = element.Title;

                            for (byte i = 0; i <= element.Duration - 1; i++)
                            {
                                dgvShedule.Rows[rowIndex + i].Cells[columnIndex].Style.BackColor = Color.Gray;
                            }

                            rowIndex = 0;
                            columnIndex = 0;
                        }
                    }

                    if (repeatingTasks.Count != 0)
                    {
                        foreach (var element in repeatingTasks)
                        {
                            for (byte i = 0; i < 17; i++)
                            {
                                if (dgvShedule.Rows[i].HeaderCell.Value.ToString().Length == 4)
                                {
                                    if (Convert.ToInt32(dgvShedule.Rows[i].HeaderCell.Value.ToString().Substring(0, 1)) == element.Time.Hours)
                                    {
                                        rowIndex = i;
                                    }
                                }
                                else
                                {
                                    if (Convert.ToInt32(dgvShedule.Rows[i].HeaderCell.Value.ToString().Substring(0, 2)) == element.Time.Hours)
                                    {
                                        rowIndex = i;
                                    }
                                }
                            }

                            for (byte i = 0; i < 7; i++)
                            {
                                if (Convert.ToDateTime(dgvShedule.Columns[i].HeaderText).ToString("dddd") == element.Day)
                                {
                                    columnIndex = i;
                                }
                            }

                            dgvShedule.Rows[rowIndex].Cells[columnIndex].Value = element.Title;

                            for (byte i = 0; i <= element.Duration - 1; i++)
                            {
                                dgvShedule.Rows[rowIndex + i].Cells[columnIndex].Style.BackColor = Color.Gray;
                            }

                            rowIndex = 0;
                            columnIndex = 0;
                        }
                    }
                    break;
                case "SamenSterk.Models.Grade":
                    /*if (grades != null)
                    { 

                    }*/
                    break;
                case "SamenSterk.Models.Appointment":
                    /*if (appointments != null)
                    { 

                    }*/
                    break;
                case "SamenSterk.Models.Subject":
                    /*if (subjects != null)
                    { 

                    }*/
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Determine which type to from the DataGridView.
        /// </summary>
        /// <param name="obj">Typeof the object.</param>
        public void DeleteFromGrid(Type obj)
        {
            switch (obj.ToString())
            {
                case "SamenSterk.Models.Task":
                    int i = 0;
                    Task taskQuery = (from task in tasks
                                      where task.Date == Convert.ToDateTime(dgvShedule.Columns[cellPos[1]].HeaderText + " " + dgvShedule.Rows[cellPos[0]].HeaderCell.Value.ToString())
                                      select task).FirstOrDefault();

                    RepeatingTask repeatingTaskQuery = (from repeatingTask in repeatingTasks
                                                        where repeatingTask.Day == Convert.ToDateTime(dgvShedule.Columns[cellPos[1]].HeaderText).ToString("dddd") && repeatingTask.Time == TimeSpan.Parse(dgvShedule.Rows[cellPos[0]].HeaderCell.Value.ToString())
                                                        select repeatingTask).FirstOrDefault();

                    if (taskQuery != null)
                    {
                        dgvShedule.Rows[cellPos[0]].Cells[cellPos[1]].Value = "";

                        do
                        {
                            dgvShedule.Rows[cellPos[0] + i].Cells[cellPos[1]].Style.BackColor = Color.Empty;
                            i++;
                        }
                        while (dgvShedule.Rows[cellPos[0] + i].Cells[cellPos[1]].Value == null && dgvShedule.Rows[cellPos[0] + i].Cells[cellPos[1]].Style.BackColor.IsEmpty == false && cellPos[0] + i - 1 < dgvShedule.Rows.Count);

                        taskController.Delete(taskQuery);
                    }
                    else
                    {
                        dgvShedule.Rows[cellPos[0]].Cells[cellPos[1]].Value = "";

                        do
                        {
                            dgvShedule.Rows[cellPos[0] + i].Cells[cellPos[1]].Style.BackColor = Color.Empty;
                            i++;
                        }
                        while (dgvShedule.Rows[cellPos[0] + i].Cells[cellPos[1]].Value == null && dgvShedule.Rows[cellPos[0] + i].Cells[cellPos[1]].Style.BackColor.IsEmpty == false && cellPos[0] + i - 1 < dgvShedule.Rows.Count);

                        repeatingTaskController.Delete(repeatingTaskQuery);
                    }
                    break;
                case "SamenSterk.Models.Grade":
                    /*if (grades != null)
                    { 

                    }*/
                    break;
                case "SamenSterk.Models.Appointment":
                    /*if (appointments != null)
                    { 

                    }*/
                    break;
                case "SamenSterk.Models.Subject":
                    /*if (subjects != null)
                    { 

                    }*/
                    break;
                default:
                    break;
            }
        }

        private void btnAddColumn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtColumnName.Text))
            {
                dgvGrades.Columns.Add("clm" + txtColumnName.Text, txtColumnName.Text);
                lblInsertName.Visible = false;
            }
            else
            {
                lblInsertName.Visible = true;
            }
            txtColumnName.Text = "";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            userController.LogOff(typeof(Login));
            logout = true;
            this.Close();
        }

        private void dgvShedule_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //checks if it didn't touched the headers
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                string cellContent = "";
                cellPos = new int[] { e.RowIndex, e.ColumnIndex }; //gets the position of the selected cell

                if (dgvShedule.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    //if the cell value has content
                    cellContent = dgvShedule.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
                else if (!dgvShedule.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor.IsEmpty)
                {
                    //if the cell value is empty, but is different colored
                    //look up to most upper cell with value
                    int i = 0;

                    do
                    {
                        if (dgvShedule.Rows[e.RowIndex - i].Cells[e.ColumnIndex].Value != null)
                        {
                            cellContent = dgvShedule.Rows[e.RowIndex - i].Cells[e.ColumnIndex].Value.ToString();
                            cellPos = new int[] { e.RowIndex - i, e.ColumnIndex }; //gets the position of the selected cell
                        }
                        i++;
                    }
                    while (dgvShedule.Rows[e.RowIndex - i + 1].Cells[e.ColumnIndex].Value == null);
                }
                else
                {
                    //the cell is empty.
                    cellContent = null;
                }

                if (string.IsNullOrEmpty(cellContent))
                {
                    if (selectedUser.Id == currentUser.Id)
                    {
                        AddTask addTask = new AddTask(this, Convert.ToDateTime(dgvShedule.Columns[cellPos[1]].HeaderText + " " + dgvShedule.Rows[cellPos[0]].HeaderCell.Value.ToString()), currentUser.Id);
                        addTask.ShowDialog();
                        tasks = taskController.Details(currentUser.Id);
                    }
                    else
                    {
                        MessageBox.Show("Kan taken voor andere gebruikers niet toevoegen/wijzigen.");
                    }
                }
                else
                {
                    Task taskQuery = (from task in tasks
                                      where task.Date == Convert.ToDateTime(dgvShedule.Columns[cellPos[1]].HeaderText + " " + dgvShedule.Rows[cellPos[0]].HeaderCell.Value.ToString())
                                      select task).FirstOrDefault();

                    RepeatingTask repeatingTaskQuery = (from repeatingTask in repeatingTasks
                                                        where repeatingTask.Day == Convert.ToDateTime(dgvShedule.Columns[cellPos[1]].HeaderText).ToString("dddd")
                                                        select repeatingTask).FirstOrDefault();

                    if (selectedUser.Id == currentUser.Id)
                    {
                        if (taskQuery != null)
                        {

                            EditTask editTask = new EditTask(this, new Task() { Id = taskQuery.Id, UserId = currentUser.Id, Title = taskQuery.Title, Duration = taskQuery.Duration, Label = taskQuery.Label }, Convert.ToDateTime(dgvShedule.Columns[cellPos[1]].HeaderText + " " + dgvShedule.Rows[cellPos[0]].HeaderCell.Value.ToString()));
                            editTask.ShowDialog();
                            tasks = taskController.Details(currentUser.Id);
                            repeatingTasks = repeatingTaskController.Details(currentUser.Id);

                        }
                        else if (repeatingTaskQuery != null)
                        {
                            EditTask editTask = new EditTask(this, new RepeatingTask() { Id = repeatingTaskQuery.Id, UserId = currentUser.Id, Title = repeatingTaskQuery.Title, Duration = repeatingTaskQuery.Duration, Label = repeatingTaskQuery.Label }, Convert.ToDateTime(dgvShedule.Columns[cellPos[1]].HeaderText + " " + dgvShedule.Rows[cellPos[0]].HeaderCell.Value.ToString()));
                            editTask.ShowDialog();
                            tasks = taskController.Details(currentUser.Id);
                            repeatingTasks = repeatingTaskController.Details(currentUser.Id);
                        }
                        else
                        {
                            MessageBox.Show("Kon de taak niet ophalen.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kan taken voor andere gebruikers niet toevoegen/wijzigen.");
                    }
                }
            }
        }

        //MAIN SHEDULE
        private void dgvShedule_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EditSchedule editSchedule = new EditSchedule(this, Convert.ToDateTime(this.dgvShedule.Columns[0].HeaderText));
            editSchedule.ShowDialog();

            for (int i = 0; i < 7; i++)
            {
                dgvShedule.Columns[i].HeaderText = startDate.AddDays(i).ToString("d");
                LoadToGrid(typeof(Task));
            }
        }

        void Shedule_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (logout != true)
            {
                Application.Exit();
            }
        }

        private void Shedule_Load(object sender, EventArgs e)
        {
            LoadToGrid(typeof(Task));
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            DateTime firstDate = Convert.ToDateTime(dgvShedule.Columns[0].HeaderText).AddDays(-1);


            if (Convert.ToDateTime(dgvShedule.Columns[0].HeaderText).AddDays(-7) > DateTime.Today)
            {
                for (int i = 0; i < 7; i++)
                {
                    dgvShedule.Columns[6 - i].HeaderText = firstDate.AddDays(-i).ToString("dd-MM-yyyy");
                    LoadToGrid(typeof(Task));
                }
            }
            else
            {
                for (int i = 0; i < 7; i++)
                {
                    dgvShedule.Columns[i].HeaderText = DateTime.Today.AddDays(i).ToString("dd-MM-yyyy");
                    LoadToGrid(typeof(Task));
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            DateTime lastDate = Convert.ToDateTime(dgvShedule.Columns[6].HeaderText).AddDays(1);

            for (int i = 0; i < 7; i++)
            {
                dgvShedule.Columns[i].HeaderText = lastDate.AddDays(i).ToString("dd-MM-yyyy");
                LoadToGrid(typeof(Task));
            }
        }

        private void cbUsernames_Click(object sender, EventArgs e)
        {
            List<User> users = new List<User>();
            users = userController.Details(currentUser);
            cbUsernames.Items.Clear();
            cbUsernames.Items.Add("Ik");
            cbUsernames.SelectedIndex = 0;

            if (users != null)
            {
                foreach (User element in users)
                {
                    cbUsernames.Items.Add(element.Username);
                }             
            }
        }

        private void cbUsernames_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<User> users = new List<User>();
            User selected = new User();
            if (cbUsernames.SelectedIndex != 0)
            {
                users = userController.Details(currentUser);
                string comboSelectedValue = cbUsernames.SelectedItem.ToString(); 

                selected = (from user in users
                            where user.Username == cbUsernames.SelectedItem.ToString()
                            select user).FirstOrDefault();
                this.selectedUser = selected;

                if (selected != null)
                {
                    tasks = taskController.Details(selected.Id);
                    repeatingTasks = repeatingTaskController.Details(selected.Id);
                    LoadToGrid(typeof(Task));
                }
            }
            else
            {
                this.selectedUser = currentUser;
                tasks = taskController.Details(currentUser.Id);
                repeatingTasks = repeatingTaskController.Details(currentUser.Id);
                LoadToGrid(typeof(Task));
            }
        }
    }
}