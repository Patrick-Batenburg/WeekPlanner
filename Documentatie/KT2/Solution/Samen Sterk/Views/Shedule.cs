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
        private List<Grade> grades;
        private List<Subject> subjects;
        private List<Appointment> appointments;
        private TaskController taskController;
        private RepeatingTaskController repeatingTaskController;
        private UserController userController;
        private GradeController gradeController;
        private SubjectController subjectController;
        private AppointmentController appointmentController;
        private byte selectedTabIndex;

        /// <summary>
        /// Initializes a new instance of the form Shedule class.
        /// </summary>
        /// <param name="model">User details to extract.</param>
        public Shedule(User model)
        {
            InitializeComponent();
            this.currentUser = model;
            this.selectedUser = currentUser;
            this.FormClosing += Shedule_FormClosing;
            cellPos = new int[2];
            logout = false;
            tasks = new List<Task>();
            repeatingTasks = new List<RepeatingTask>();
            grades = new List<Grade>();
            subjects = new List<Subject>();
            appointments = new List<Appointment>();
            taskController = new TaskController();
            repeatingTaskController = new RepeatingTaskController();
            userController = new UserController();
            gradeController = new GradeController();
            subjectController = new SubjectController();
            appointmentController = new AppointmentController();
            dgvShedule.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvShedule.ColumnHeaderMouseDoubleClick += dgvShedule_ColumnHeaderMouseDoubleClick;
            dgvGrades.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvGrades.RowHeaderMouseDoubleClick += dgvGrades_RowHeaderMouseDoubleClick;
            dgvGrades.MouseUp += dgvGrades_MouseUp;
            dgvGrades.AllowUserToAddRows = false;
            dgvGrades.ColumnHeadersVisible = false;
            dgvGrades.ColumnCount = 1;
            dgvAppointments.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvAppointments.AllowUserToAddRows = false;
            tasks = taskController.Details(model.Id);
            repeatingTasks = repeatingTaskController.Details(model.Id);
            tabControl.Selected += tabControl_Selected;

            for (int i = 0; i < dgvShedule.Columns.Count; i++) 
            {
                dgvShedule.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable; 
            }

            for (int i = 0; i < 7; i++)
            {
                dgvShedule.Columns[i].HeaderText = DateTime.Today.AddDays(i).ToString("dd-MM-yyyy");
            }

            if (model.Role != "Admin")
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
                    tasks = taskController.Details(currentUser.Id);
                    repeatingTasks = repeatingTaskController.Details(currentUser.Id);

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
                        foreach (Task element in taskQuery)
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
                        foreach (RepeatingTask element in repeatingTasks)
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
                    int index = -1;
                    dgvGrades.CellValueChanged -= dgvGrades_CellValueChanged;

                    dgvGrades.Rows.Clear();
                    grades = gradeController.Details(selectedUser.Id);
                    subjects = subjectController.Details(selectedUser.Id);

                    if (grades.Count != 0)
                    {
                        dgvGrades.ColumnCount = grades.Max(grade => Convert.ToInt32(grade.ColumnIndex)) + 1;
                    }


                    if (subjects.Count != 0)
                    {
                        for (int i = 0; i < subjects.Count; i++)
                        {
                            dgvGrades.Rows.Add();
                            dgvGrades.Rows[i].HeaderCell.Value = subjects[i].Name;
                        }

                        if (grades.Count != 0)
                        {
                            for (int i = 0; i < grades.Count; i++)
                            {
                                if ( grades[i].Number == 10.0f)
                                {
                                    dgvGrades[Convert.ToInt32(grades[i].ColumnIndex), Convert.ToInt32(grades[i].RowIndex)].Value = grades[i].Number.ToString("0");
                                }
                                else
                                {
                                    dgvGrades[Convert.ToInt32(grades[i].ColumnIndex), Convert.ToInt32(grades[i].RowIndex)].Value = grades[i].Number.ToString("0.0");
                                }
                            }

                            index = (from row in dgvGrades.Rows.Cast<DataGridViewRow>()
                                     where row.Cells[dgvGrades.ColumnCount - 1].Value != null && row.Cells[dgvGrades.ColumnCount - 1].Value.ToString().Length > 0
                                     select row.Index).First();
                        }
                    }

                    if (index != -1)
                    {
                        dgvGrades.ColumnCount += 1;
                    }

                    dgvGrades.CellValueChanged += dgvGrades_CellValueChanged;
                    break;
                case "SamenSterk.Models.Appointment":
                    /*if (appointments != null)
                    { 

                    }*/
                    break;
                default:
                    break;
            }
        }

        #region Grade eventhandlers
        /// <summary>
        /// Occurs when the Button control is clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param> 
        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            int result = 0;
            if (selectedUser.Id == currentUser.Id)
            {
                if (!string.IsNullOrWhiteSpace(txtSubjectName.Text))
                {
                    result = subjectController.Create(new Subject()
                    {
                        RowIndex = Convert.ToUInt32(dgvGrades.RowCount),
                        UserId = selectedUser.Id,
                        Name = txtSubjectName.Text
                    });

                    if (result != 2)
                    {
                        LoadToGrid(typeof(Grade));
                        lblInsertName.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Er bestaat al een vak met dezelfde naam.");
                    }
                }
                else
                {
                    lblInsertName.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Kan vaken voor andere gebruikers niet toevoegen.");
            }

            txtSubjectName.Text = "";
        }

        /// <summary>
        /// Occurs when a row header is double-clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellMouseEventArgs"/> instance containing the event data.</param> 
        void dgvGrades_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (selectedUser.Id == currentUser.Id)
            {
                Subject model = (from subject in subjects
                                 where subject.RowIndex == Convert.ToUInt32(e.RowIndex)
                                 select subject).FirstOrDefault();

                EditSubject editSubject = new EditSubject(model);
                editSubject.ShowDialog();
                LoadToGrid(typeof(Grade));
            }
            else
            {
                MessageBox.Show("Kan vaken voor andere gebruikers niet wijzigen.");
            }
        }

        /// <summary>
        /// Occurs when the mouse pointer is over the control and a mouse button is released.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param> 
        void dgvGrades_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (dgvGrades.HitTest(e.X, e.Y) == System.Windows.Forms.DataGridView.HitTestInfo.Nowhere)
                {
                    dgvGrades.EndEdit();
                }
            }
        }

        /// <summary>
        /// Occurs when the value of a cell changes.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param> 
        private void dgvGrades_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1 && subjects.Count == dgvGrades.RowCount)
            {
                if (selectedUser.Id == currentUser.Id)
                {
                    int result = 0;
                    Grade query = (from grade in grades
                                   where grade.RowIndex == Convert.ToUInt32(e.RowIndex) && grade.ColumnIndex == Convert.ToUInt32(e.ColumnIndex)
                                   select grade).FirstOrDefault();

                    if (query == null && string.IsNullOrEmpty(dgvGrades[e.ColumnIndex, e.RowIndex].Value.ToString()) == false)
                    {
                        float number;
                        string value = dgvGrades[e.ColumnIndex, e.RowIndex].Value.ToString();
                        Single.TryParse(value, out number);

                        if (number > 10.0 || number < 1.0)
                        {
                            number = 1.0f;
                        }

                        result = gradeController.Create(new Grade()
                        {
                            ColumnIndex = Convert.ToUInt32(e.ColumnIndex),
                            RowIndex = Convert.ToUInt32(e.RowIndex),
                            UserId = selectedUser.Id,
                            Number = (float)Math.Round(number, 1)
                        });

                        if (result == 0)
                        {
                            MessageBox.Show("Kon het cijfer niet toevoegen.");
                        }
                    }
                    else if (query != null && string.IsNullOrEmpty(dgvGrades[e.ColumnIndex, e.RowIndex].Value.ToString()) == true)
                    {
                        result = gradeController.Delete(query);

                        if (result == 0)
                        {
                            MessageBox.Show("Kon het cijfer niet verwijderen.");
                        }
                    }
                    else if (query != null && string.IsNullOrEmpty(dgvGrades[e.ColumnIndex, e.RowIndex].Value.ToString()) != true)
                    {
                        float number;
                        string value = dgvGrades[e.ColumnIndex, e.RowIndex].Value.ToString();
                        Single.TryParse(value, out number);

                        if (number > 10.0 || number < 1.0)
                        {
                            number = 1.0f;
                        }

                        query.Number = Convert.ToSingle(Convert.ToDecimal(number).ToString("0.0"));
                        result = gradeController.Edit(query);

                        if (result == 0)
                        {
                            MessageBox.Show("Kon het cijfer niet wijzigen.");
                        }
                    }

                    LoadToGrid(typeof(Grade));
                }
            }
            else
            {
                MessageBox.Show("Kan cijfers voor andere gebruikers niet toevoegen/wijzigen.");
            }
        }
        #endregion Grade eventhandlers

        #region Task eventhandlers
        /// <summary>
        /// Occurs when the user double-clicks anywhere in a cell.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param> 
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
                        AddTask addTask = new AddTask(Convert.ToDateTime(dgvShedule.Columns[cellPos[1]].HeaderText + " " + dgvShedule.Rows[cellPos[0]].HeaderCell.Value.ToString()), currentUser.Id);
                        addTask.ShowDialog();
                        LoadToGrid(typeof(Task));
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
                                                        where repeatingTask.Day == Convert.ToDateTime(dgvShedule.Columns[cellPos[1]].HeaderText).ToString("dddd") && repeatingTask.Time.ToString(@"h\:mm") == dgvShedule.Rows[cellPos[0]].HeaderCell.Value.ToString()
                                                        select repeatingTask).FirstOrDefault();

                    if (selectedUser.Id == currentUser.Id)
                    {
                        if (taskQuery != null)
                        {
                            EditTask editTask = new EditTask(new Task() { Id = taskQuery.Id, UserId = currentUser.Id, Title = taskQuery.Title, Duration = taskQuery.Duration, Label = taskQuery.Label }, Convert.ToDateTime(dgvShedule.Columns[cellPos[1]].HeaderText + " " + dgvShedule.Rows[cellPos[0]].HeaderCell.Value.ToString()));
                            editTask.ShowDialog();
                            LoadToGrid(typeof(Task));
                        }
                        else if (repeatingTaskQuery != null)
                        {
                            EditTask editTask = new EditTask(new RepeatingTask() { Id = repeatingTaskQuery.Id, UserId = currentUser.Id, Title = repeatingTaskQuery.Title, Duration = repeatingTaskQuery.Duration, Label = repeatingTaskQuery.Label }, Convert.ToDateTime(dgvShedule.Columns[cellPos[1]].HeaderText + " " + dgvShedule.Rows[cellPos[0]].HeaderCell.Value.ToString()));
                            editTask.ShowDialog();
                            LoadToGrid(typeof(Task));
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

        /// <summary>
        /// Occurs when a column header is double-clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param> 
        private void dgvShedule_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EditSchedule editSchedule = new EditSchedule(this, Convert.ToDateTime(this.dgvShedule.Columns[0].HeaderText));
            editSchedule.ShowDialog();

            for (int i = 0; i < 7; i++)
            {
                dgvShedule.Columns[i].HeaderText = startDate.AddDays(i).ToString("dd-MM-yyyy");
            }

            LoadToGrid(typeof(Task));
        }

        /// <summary>
        /// Occurs when the Button control is clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param> 
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

        /// <summary>
        /// Occurs when the Button control is clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param> 
        private void btnNext_Click(object sender, EventArgs e)
        {
            DateTime lastDate = Convert.ToDateTime(dgvShedule.Columns[6].HeaderText).AddDays(1);

            for (int i = 0; i < 7; i++)
            {
                dgvShedule.Columns[i].HeaderText = lastDate.AddDays(i).ToString("dd-MM-yyyy");
                LoadToGrid(typeof(Task));
            }
        }
        #endregion Task eventhandlers

        #region Global eventhandlers
        /// <summary>
        /// Occurs before the form is closed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        void Shedule_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (logout != true)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Occurs when the Button control is clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param> 
        private void btnLogout_Click(object sender, EventArgs e)
        {
            userController.LogOff(typeof(Login));
            logout = true;
            this.Close();
        }

        /// <summary>
        /// Occurs when a tab is selected.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TabControlEventArgs"/> instance containing the event data.</param> 
        void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPage.Text)
            {
                case "Rooster":
                    btnPrevious.Enabled = true;
                    btnNext.Enabled = true;
                    selectedTabIndex = 0;
                    LoadToGrid(typeof(Task));
                    break;
                case "Cijfers":
                    btnPrevious.Enabled = false;
                    btnNext.Enabled = false;
                    selectedTabIndex = 1;
                    LoadToGrid(typeof(Grade));
                    break;
                case "Belangrijke Afspraken":
                    btnPrevious.Enabled = false;
                    btnNext.Enabled = false;
                    selectedTabIndex = 2;
                    LoadToGrid(typeof(Appointment));
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Occurs when the ComboBox control is clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param> 
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

        /// <summary>
        /// Occurs when the SelectedIndex property has changed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param> 
        private void cbUsernames_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<User> users = new List<User>();
            User selected = new User();

            if (cbUsernames.SelectedIndex != 0)
            {
                users = userController.Details(currentUser);
                selected = (from user in users
                            where user.Username == cbUsernames.SelectedItem.ToString()
                            select user).FirstOrDefault();
                this.selectedUser = selected;

                if (selected != null)
                {
                    switch (selectedTabIndex)
                    {
                        case 0:
                            LoadToGrid(typeof(Task));
                            break;
                        case 1:
                            LoadToGrid(typeof(Grade));
                            break;
                        case 2:
                            LoadToGrid(typeof(Appointment));
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                this.selectedUser = currentUser;

                switch (selectedTabIndex)
                {
                    case 0:
                        LoadToGrid(typeof(Task));
                        break;
                    case 1:
                        LoadToGrid(typeof(Grade));
                        break;
                    case 2:
                        LoadToGrid(typeof(Appointment));
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion Global eventhandlers
    }
}