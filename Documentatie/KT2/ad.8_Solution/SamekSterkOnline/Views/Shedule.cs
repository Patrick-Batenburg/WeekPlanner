using SamenSterkOnline.Controllers;
using SamenSterkOnline.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace SamenSterkOnline.Views
{
    public partial class Shedule : Form
    {
        //color help:
        //#ffffff //white background
        //#5a5a5a //black / grey for text
        //#bd7cbb (orchid) //purple colors
        public DateTime startDate;
        public DateTime appointmentDate;
        public User currentUser;
        public User selectedUser;
        private int[] cellPos;
        private int AppointdateRowIndex;
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
            cellPos = new int[2];
            logout = false;

            grades = new List<Grade>();
            subjects = new List<Subject>();
            appointments = new List<Appointment>();

            taskController = new TaskController();
            repeatingTaskController = new RepeatingTaskController();
            userController = new UserController();
            gradeController = new GradeController();
            subjectController = new SubjectController();
            appointmentController = new AppointmentController();

            for (int i = 0; i < dgvShedule.Columns.Count; i++)
            {
                dgvShedule.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            for (int i = 0; i < 7; i++)
            {
                dgvShedule.Columns[i].HeaderText = DateTime.Today.AddDays(i).ToString("dd-MM-yyyy");
            }

            lblUsername.Text = model.Username;
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
                cbUsernames.Items.Add(currentUser.Username + " (ik)");
                cbUsernames.SelectedIndex = 0;
            }

            LoadToGrid(typeof(Task));
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
                case "SamenSterkOnline.Models.Task":
                    dgvShedule.Rows.Clear();
                    tasks = taskController.Details(selectedUser.Id);
                    repeatingTasks = repeatingTaskController.Details(selectedUser.Id);

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
                                if (rowIndex + i < dgvShedule.RowCount)
                                {
                                    dgvShedule.Rows[rowIndex + i].Cells[columnIndex].Style.BackColor = ColorTranslator.FromHtml("#673AB7");
                                    dgvShedule.Rows[rowIndex + i].Cells[columnIndex].Style.ForeColor = Color.White;
                                }
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
                                //Checks if the header time is longer than 4 characters
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
                                dgvShedule.Rows[rowIndex + i].Cells[columnIndex].Style.BackColor = ColorTranslator.FromHtml("#7986CB");
                                dgvShedule.Rows[rowIndex + i].Cells[columnIndex].Style.ForeColor = Color.White;
                            }

                            rowIndex = 0;
                            columnIndex = 0;
                        }
                    }
                    break;
                case "SamenSterkOnline.Models.Grade":
                    int index = -1;
                    dgvGrades.CellValueChanged -= dgvGrades_CellValueChanged;
                    dgvGrades.Rows.Clear();
                    dgvGrades.ColumnCount = 1;
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
                                if (grades[i].Number == 10.0f)
                                {
                                    dgvGrades[Convert.ToInt32(grades[i].ColumnIndex), Convert.ToInt32(grades[i].RowIndex)].Value = grades[i].Number.ToString("0").Replace('.', ',');
                                }
                                else
                                {
                                    dgvGrades[Convert.ToInt32(grades[i].ColumnIndex), Convert.ToInt32(grades[i].RowIndex)].Value = grades[i].Number.ToString("0.0").Replace('.', ',');
                                }
                            }

                            if (dgvGrades.ColumnCount > 0)
                            {
                                List<DataGridViewRow> rows = (from row in dgvGrades.Rows.Cast<DataGridViewRow>()
                                                              select row).ToList();

                                if (rows.Count != 0)
                                {
                                    index = (from row in rows
                                             where row.Cells[dgvGrades.ColumnCount - 1].Value != null
                                             select row.Index).FirstOrDefault();
                                }
                            }
                        }
                    }

                    if (index != -1)
                    {
                        dgvGrades.ColumnCount += 1;
                    }

                    dgvGrades.CellValueChanged += dgvGrades_CellValueChanged;
                    break;
                case "SamenSterkOnline.Models.Appointment":
                    dgvAppointments.CellValueChanged -= dgvAppointments_CellValueChanged;
                    dgvAppointments.DataSource = null;
                    dgvAppointments.Rows.Clear();
                    appointments = appointmentController.Details(selectedUser.Id);

                    appointments = (from appointment in appointments
                                    where appointment.Date > DateTime.Today || appointment.Date == new DateTime(1980, 1, 1)
                                    select appointment).ToList();

                    DataTable dataTable = new DataTable();  
                    dataTable.Columns.Add("Naam", typeof(string));
                    dataTable.Columns.Add("Datum", typeof(string));
                    dataTable.Columns.Add("Verwijderen?", typeof(bool));
                    dataTable.Columns.Add("Id", typeof(uint));

                    if (appointments.Count != 0)
                    {
                        for (int i = 0; i < appointments.Count; i++)
                        {
                            if (appointments[i].Date.ToString("dd-MM-yyyy HH:mm") == new DateTime(1980, 1, 1).ToString("dd-MM-yyyy HH:mm"))
                            {
                                dataTable.Rows.Add(appointments[i].Name, "[Geen datum]", false, appointments[i].Id);  
                            }
                            else
                            {
                                dataTable.Rows.Add(appointments[i].Name, appointments[i].Date.ToString("dd-MM-yyyy HH:mm"), false, appointments[i].Id);  
                            }
                        }
                    }
                    dgvAppointments.DataSource = dataTable;
                    dgvAppointments.Columns[1].ReadOnly = true;
                    dgvAppointments.Columns[1].Resizable = DataGridViewTriState.False;
                    dgvAppointments.Columns[2].Resizable = DataGridViewTriState.False;
                    dgvAppointments.Columns[dgvAppointments.ColumnCount - 1].Visible = false;
                    dgvAppointments.CellValueChanged += dgvAppointments_CellValueChanged;
                    break;
                default:
                    break;
            }
        }

        #region Task eventhandlers
        /// <summary>
        /// Occurs when the user double-clicks anywhere in a cell. Gets the clicked cell position and chooses depending on the value of the cell to display the AddTask form or EditTask form.
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
        /// Occurs when a column header is double-clicked. Displays the EditDate form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param> 
        private void dgvShedule_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EditDate editSchedule = new EditDate(this, Convert.ToDateTime(this.dgvShedule.Columns[0].HeaderText));
            editSchedule.ShowDialog();
            LoadToGrid(typeof(Task));
        }

        /// <summary>
        /// Sets the header date of the selected date.
        /// </summary>
        public void SetHeaderDate()
        {
            for (int i = 0; i < 7; i++)
            {
                dgvShedule.Columns[i].HeaderText = startDate.AddDays(i).ToString("dd-MM-yyyy");
            }
        }

        /// <summary>
        /// Occurs when the Button control is clicked. Goes back to 7 days of the current date in the DataGridView if it doesn't exceed the date of today.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param> 
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            DateTime dateTime;
            DateTime firstDate = Convert.ToDateTime(dgvShedule.Columns[0].HeaderText).AddDays(-1);

            if (Convert.ToDateTime(dgvShedule.Columns[0].HeaderText).AddDays(-7) > DateTime.Today)
            {
                dateTime = firstDate;
            }
            else
            {
                dateTime = DateTime.Today.AddDays(6);
            }

            for (int i = 0; i < 7; i++)
            {
                dgvShedule.Columns[6 - i].HeaderText = dateTime.AddDays(-i).ToString("dd-MM-yyyy");
                LoadToGrid(typeof(Task));
            }
        }

        /// <summary>
        /// Occurs when the Button control is clicked. Goes forward for 7 days of the current date in the DataGridView if it doesn't exceed the max DateTime value.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param> 
        private void btnNext_Click(object sender, EventArgs e)
        {
            DateTime lastDate = Convert.ToDateTime(dgvShedule.Columns[6].HeaderText);

            if (lastDate <= DateTime.MaxValue.AddDays(-6))
            {
                lastDate = Convert.ToDateTime(dgvShedule.Columns[6].HeaderText).AddDays(1);

                for (int i = 0; i < 7; i++)
                {
                    dgvShedule.Columns[i].HeaderText = lastDate.AddDays(i).ToString("dd-MM-yyyy");
                    LoadToGrid(typeof(Task));
                }
            }
            else
            {
                lastDate = Convert.ToDateTime(dgvShedule.Columns[6].HeaderText);
                for (int i = 0; i < 7; i++)
                {
                    dgvShedule.Columns[i].HeaderText = DateTime.MaxValue.AddDays(-6).AddDays(i).ToString("dd-MM-yyyy");
                    LoadToGrid(typeof(Task));
                }
            }
        }
        #endregion Task eventhandlers

        #region Grade eventhandlers
        /// <summary>
        /// Occurs when the Button control is clicked. Adds a new Subject.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param> 
        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            //adds a subject to the grades datagrid
            int result = 0;
            if (selectedUser.Id == currentUser.Id)
            {
                if (!string.IsNullOrWhiteSpace(txtSubjectName.Text))
                {
                    if (txtSubjectName.Text.Length > 64)
                    {
                        MessageBox.Show("Naam van het vak is te lang.");
                    }
                    else
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
        /// Occurs when a row header is double-clicked. Displays the EditSubject form, which edits an existing Subject.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellMouseEventArgs"/> instance containing the event data.</param> 
        private void dgvGrades_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
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
                MessageBox.Show("Kan vakken voor andere gebruikers niet wijzigen.");
            }
        }

        /// <summary>
        /// Occurs when the mouse pointer is over the control and a mouse button is released. Exits edit mode when not clicked on a cell.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param> 
        private void dgvGrades_MouseUp(object sender, MouseEventArgs e)
        {
            //exits edit mode when editing grades
            if (e.Button == MouseButtons.Left)
            {
                if (dgvGrades.HitTest(e.X, e.Y) == System.Windows.Forms.DataGridView.HitTestInfo.Nowhere)
                {
                    dgvGrades.EndEdit();
                }
            }
        }

        /// <summary>
        /// Occurs when a character. space or backspace key is pressed while the control has focus. Raises the btnAddSubject_Click event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param> 
        private void txtSubjectName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnAddSubject_Click(sender, e);
            }
        }

        /// <summary>
        /// Occurs when the value of a cell changes. Adds a new Grade if there wasn't no value. Edit an existing Grade if the value changed. Deletes an existing Grade if the value is empty.
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

                    if (query == null && dgvGrades[e.ColumnIndex, e.RowIndex].Value != null)
                    {
                        //adds a grade
                        float number;
                        string value = dgvGrades[e.ColumnIndex, e.RowIndex].Value.ToString().Replace(',', '.');
                        float.TryParse(value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out number);

                        if (number > 10.0 || number < 1.0)
                        {
                            MessageBox.Show("Kon het cijfer niet toevoegen.\nWaarde moet tussen de 1,0 en 10 liggen.");
                            result = 2;
                        }
                        else
                        {
                            result = gradeController.Create(new Grade()
                            {
                                ColumnIndex = Convert.ToUInt32(e.ColumnIndex),
                                RowIndex = Convert.ToUInt32(e.RowIndex),
                                UserId = selectedUser.Id,
                                Number = (float)Math.Round(number, 1)
                            });
                        }

                        if (result == 0)
                        {
                            MessageBox.Show("Kon het cijfer niet toevoegen.");
                        }
                    }
                    else if (query != null && dgvGrades[e.ColumnIndex, e.RowIndex].Value == null)
                    {
                        //deletes the grade
                        result = gradeController.Delete(query);

                        if (result == 0)
                        {
                            MessageBox.Show("Kon het cijfer niet verwijderen.");
                        }
                    }
                    else if (query != null && string.IsNullOrEmpty(dgvGrades[e.ColumnIndex, e.RowIndex].Value.ToString()) != true)
                    {
                        //edits the grade
                        float number;
                        string value = dgvGrades[e.ColumnIndex, e.RowIndex].Value.ToString().Replace(',', '.');
                        float.TryParse(value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out number);

                        if (number > 10.0 || number < 1.0)
                        {
                            MessageBox.Show("Kon het cijfer niet wijzigen.\nWaarde moet tussen de 1,0 en 10 liggen.");
                            result = 2;
                            number = 1.0f;
                        }
                        else
                        {
                            query.Number = (float)Math.Round(number, 1);
                            result = gradeController.Edit(query);
                        }

                        if (result == 0)
                        {
                            MessageBox.Show("Kon het cijfer niet wijzigen.");
                        }
                    }

                    LoadToGrid(typeof(Grade));
                }
                else
                {
                    MessageBox.Show("Kan cijfers voor andere gebruikers niet toevoegen/wijzigen.");
                }
            }
        }
        #endregion Grade eventhandlers

        #region Appointment eventhandlers
        /// <summary>
        /// Occurs when the user double-clicks anywhere in a cell. displays the EditAppointment form, which edits the date of the Appointment.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAppointments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1 && e.ColumnIndex == 1)
            {
                if (selectedUser.Id == currentUser.Id)
                {
                    if (dgvAppointments[1, e.RowIndex].Value != null)
                    {
                        AppointdateRowIndex = e.RowIndex;
                        if (dgvAppointments[1, e.RowIndex].Value.ToString() == "[Geen datum]" || string.IsNullOrEmpty(dgvAppointments[1, e.RowIndex].Value.ToString()) == true)
                        {
                            EditAppointment editAppointment = new EditAppointment(this, DateTime.Now);
                            editAppointment.ShowDialog();
                        }
                        else
                        {
                            EditAppointment editAppointment = new EditAppointment(this, Convert.ToDateTime(dgvAppointments[1, e.RowIndex].Value));
                            editAppointment.ShowDialog();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Kan afspraken voor andere gebruikers niet toevoegen/wijzigen.");
                }
            }
        }

        /// <summary>
        /// Edits the date of the Appointment.
        /// </summary>
        public void EditAppointment()
        {
            dgvAppointments[1, AppointdateRowIndex].Value = appointmentDate.ToString("dd-MM-yyyy HH:mm");
        }

        /// <summary>
        /// Occurs when the mouse pointer is over the control and a mouse button is released. Exits edit mode when not clicked on a cell.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param> 
        private void dgvAppointments_MouseUp(object sender, MouseEventArgs e)
        {
            //exits edit mode when editing grades
            if (e.Button == MouseButtons.Left)
            {
                if (dgvAppointments.HitTest(e.X, e.Y) == System.Windows.Forms.DataGridView.HitTestInfo.Nowhere)
                {
                    dgvAppointments.EndEdit();
                }
            }
        }

        /// <summary>
        /// Occurs when the user releases a mouse button while over a cell. Exits edit mode of the cell.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellMouseEventArgs"/> instance containing the event data.</param> 
        private void dgvAppointments_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                dgvAppointments.EndEdit();
            }
        }

        /// <summary>
        /// Occurs when the value of a cell changes. Adds a new Appointment if there wasn't no value. Edit an existing Appointment if the value changed. Deletes an existing Appointment if the value is empty.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param> 
        private void dgvAppointments_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                int result = 0;
                Appointment query = null;
                uint? id = null;
                List<DataGridViewRow> rows = (from row in dgvAppointments.Rows.Cast<DataGridViewRow>()
                                              select row).ToList();

                switch (e.ColumnIndex)
                {
                    case 0:
                        if (selectedUser.Id == currentUser.Id)
                        {
                            if (string.IsNullOrEmpty(Convert.ToString(dgvAppointments[e.ColumnIndex, e.RowIndex].Value)) != true && string.IsNullOrEmpty(Convert.ToString(dgvAppointments[e.ColumnIndex + 1, e.RowIndex].Value)) == true)
                            {
                                if (Convert.ToString(dgvAppointments[e.ColumnIndex, e.RowIndex].Value).Length > 64)
                                {
                                    MessageBox.Show("De naam van de afspraak is te lang.");
                                }
                                else
                                {
                                    result = appointmentController.Create(new Appointment()
                                    {
                                        UserId = currentUser.Id,
                                        Name = Convert.ToString(dgvAppointments[e.ColumnIndex, e.RowIndex].Value),
                                    });
                                }
                            }
                            else
                            {
                                query = (from appointment in appointments
                                         where appointment.Id == Convert.ToUInt32(dgvAppointments[dgvAppointments.ColumnCount - 1, e.RowIndex].Value)
                                         select appointment).FirstOrDefault();

                                query.Name = Convert.ToString(dgvAppointments[e.ColumnIndex, e.RowIndex].Value);

                                if (query.Name.Length > 64)
                                {
                                    MessageBox.Show("De naam van de afspraak is te lang.");
                                }
                                else
                                {
                                    if (query != null)
                                    {
                                        result = appointmentController.Edit(query);
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Kan afspraken voor andere gebruikers niet toevoegen/wijzigen.");
                        }
                        break;
                    case 1:
                        if (string.IsNullOrEmpty(Convert.ToString(dgvAppointments[e.ColumnIndex, e.RowIndex].Value)) != true && string.IsNullOrEmpty(Convert.ToString(dgvAppointments[e.ColumnIndex - 1, e.RowIndex].Value)) == true)
                        {
                            result = appointmentController.Create(new Appointment()
                            {
                                UserId = currentUser.Id,
                                Date = Convert.ToDateTime(dgvAppointments[e.ColumnIndex, e.RowIndex].Value)
                            });
                        }
                        else
                        {
                            query = (from appointment in appointments
                                        where appointment.Id == Convert.ToUInt32(dgvAppointments[dgvAppointments.ColumnCount - 1, e.RowIndex].Value)
                                        select appointment).FirstOrDefault();

                            query.Date = Convert.ToDateTime(dgvAppointments[e.ColumnIndex, e.RowIndex].Value);

                            if (query != null)
                            {
                                result = appointmentController.Edit(query);
                            }
                        }
                        break;
                    case 2:
                        if (selectedUser.Id == currentUser.Id)
                        {
                            if (e.RowIndex < dgvAppointments.RowCount && string.IsNullOrEmpty(Convert.ToString(dgvAppointments[dgvAppointments.ColumnCount - 1, e.RowIndex].Value)) == false)
                            {
                                id = (from row in rows
                                      where Convert.ToBoolean(row.Cells["verwijderen?"].Value) == true
                                      select Convert.ToUInt32(row.Cells[dgvAppointments.ColumnCount - 1].Value)).FirstOrDefault();

                                query = (from appointment in appointments
                                         where appointment.Id == id
                                         select appointment).FirstOrDefault();

                                if (query != null)
                                {
                                    result = appointmentController.Delete(query);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Kan afspraken voor andere gebruikers niet verwijderen.");
                        }
                        break;
                    default:
                        break;
                }

                LoadToGrid(typeof(Appointment));              
            }
        }
        #endregion Appointment eventhandlers

        #region Global eventhandlers
        /// <summary>
        /// Occurs before the form is closed. Exits the application if the user didn't want to logout.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void Shedule_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (logout != true)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Occurs when the Button control is clicked. Close the current form and shows the login form.
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
        /// Occurs when a tab is selected. Gets the tab index and loads the data in the DataGridView.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TabControlEventArgs"/> instance containing the event data.</param> 
        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPage.Text)
            {
                case "Rooster":
                    selectedTabIndex = 0;
                    LoadToGrid(typeof(Task));
                    break;
                case "Cijfers":
                    selectedTabIndex = 1;
                    LoadToGrid(typeof(Grade));
                    break;
                case "Belangrijke Afspraken":
                    selectedTabIndex = 2;
                    LoadToGrid(typeof(Appointment));
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Occurs when the ComboBox control is clicked. Repopulates the ComboBox control's DataSource, incase a new user registered.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param> 
        private void cbUsernames_Click(object sender, EventArgs e)
        {
            string textValue = cbUsernames.Text;
            List<User> users = userController.Details(currentUser);
            ComboBox comboBox = (ComboBox)sender;

            users.Insert(0, new User()
            {
                Id = currentUser.Id,
                Username = currentUser.Username + " (Ik)"
            });

            cbUsernames.SelectedIndexChanged -= cbUsernames_SelectedIndexChanged;
            cbUsernames.DataSource = null;
            cbUsernames.Items.Clear();
            cbUsernames.DataSource = users;
            cbUsernames.ValueMember = "Id";
            cbUsernames.DisplayMember = "Username";
            cbUsernames.SelectedIndexChanged += cbUsernames_SelectedIndexChanged;
            cbUsernames.Text = textValue;
        }

        /// <summary>
        /// Occurs when the SelectedIndex property has changed. Shows the data of the selected user for the specified selected tab.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param> 
        private void cbUsernames_SelectedIndexChanged(object sender, EventArgs e)
        {
            User selected = new User();
            ComboBox comboBox = (ComboBox)sender;

            if (cbUsernames.SelectedIndex != 0)
            {
                if ((User)comboBox.SelectedItem != null)
                {
                    selected = (User)comboBox.SelectedItem;
                    cbUsernames.Text = selected.Username;
                }

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